var config = new CovidConfig();

config.LoadConfig();


for (int i = 0; i < 2; i++)
{
    Console.WriteLine($"Masukkan suhu tubuh Anda ({config.SatuanSuhu}):");
    double suhu = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine($"Berapa hari Anda mengalami demam? (batas: {config.BatasHariDeman} hari)");
    int hariDeman = Convert.ToInt32(Console.ReadLine());

    if (!conditionals(suhu, hariDeman))
    {
        Console.WriteLine(config.PesanDitolak);
    }
    else
    {
        Console.WriteLine(config.PesanDiterima);
    }

    config.UbahSatuan();

}

bool conditionals(double temp, int days)
{
    if (days > config.BatasHariDeman)
    {
        return false;
    }
    else if (config.SatuanSuhu.ToLower() == "fahrenheit")
    {
        if (temp < 97.7 || temp > 99.5) return false;
    }
    else if (config.SatuanSuhu.ToLower() == "celsius")
    {
        if (temp < 36.5 || temp > 37.5) return false;
    }
    return true;
}