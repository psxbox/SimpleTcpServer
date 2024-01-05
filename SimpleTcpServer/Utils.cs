namespace SimpleTcpServer;
public static class Utils
{
    public static (string Imei, string CommandCode, string BaseMeterAddress, uint CumulativeFlow, uint TopUpFlow, byte EquipmentStatus, byte AlertStatus, double BatteryVoltage, byte SignalRssi, byte Snr) ParseWaterMeterData(string data)
    {
        if (data.Length != 56)
            throw new ArgumentException("Invalid data length", nameof(data));

        string imei = data.Substring(0, 15);
        string commandCode = data.Substring(16, 2);
        string baseMeterAddress = data.Substring(18, 8);
        uint cumulativeFlow = BitConverter.ToUInt32(HexStringToByteArray(data.Substring(26, 8)), 0);
        uint topUpFlow = BitConverter.ToUInt32(HexStringToByteArray(data.Substring(34, 8)), 0);
        byte equipmentStatus = Convert.ToByte(data.Substring(42, 2), 16);
        byte alertStatus = Convert.ToByte(data.Substring(44, 2), 16);
        short batteryVoltageRaw = BitConverter.ToInt16(HexStringToByteArray(data.Substring(46, 4)), 0);
        double batteryVoltage = batteryVoltageRaw / 100.0;
        byte signalRssi = Convert.ToByte(data.Substring(50, 2), 10);
        byte snr = Convert.ToByte(data.Substring(52, 2), 10);

        return (imei, commandCode, baseMeterAddress, cumulativeFlow, topUpFlow, equipmentStatus, alertStatus, batteryVoltage, signalRssi, snr);
    }

    public static byte[] HexStringToByteArray(string hexString)
{
    if (hexString.Length % 2 != 0)
        throw new ArgumentException("The hex string must have an even length");

    byte[] byteArray = new byte[hexString.Length / 2];
    for (int i = 0; i < byteArray.Length; i++)
    {
        string currentHex = hexString.Substring(i * 2, 2);
        byteArray[i] = Convert.ToByte(currentHex, 16);
    }
    return byteArray;
}
}
