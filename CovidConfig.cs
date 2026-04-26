using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public class CovidConfig
{
    [JsonIgnore]
    private string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "covid_config.json");

    [JsonPropertyName("satuan_suhu")]
    public string SatuanSuhu { get; set; }

    [JsonPropertyName("batas_hari_deman")]
    public int BatasHariDeman { get; set; }

    [JsonPropertyName("pesan_ditolak")]
    public string PesanDitolak { get; set; }

    [JsonPropertyName("pesan_diterima")]
    public string PesanDiterima { get; set; }

    public CovidConfig() 
    {
        // Set default values
        SatuanSuhu = "celsius";
        BatasHariDeman = 14;
        PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

    }

    public void UbahSatuan()
    {
        if (SatuanSuhu.ToLower() == "celsius")
        {
            SatuanSuhu = "fahrenheit";
        }
        else
        {
            SatuanSuhu = "celsius";
        }
    }

    public void LoadConfig()
    {
        if (File.Exists(_filePath))
        {
            try
            {
                string jsonString = File.ReadAllText(_filePath);
                var configFromFile = JsonSerializer.Deserialize<CovidConfig>(jsonString);
                if (configFromFile != null)
                {
                    SatuanSuhu = configFromFile.SatuanSuhu;
                    BatasHariDeman = configFromFile.BatasHariDeman;
                    PesanDitolak = configFromFile.PesanDitolak;
                    PesanDiterima = configFromFile.PesanDiterima;
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal membaca konfigurasi dari file: {ex.Message}");
            }
        }
    }
}
