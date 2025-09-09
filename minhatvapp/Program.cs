using System;

public class Televisao
{
    private const int CanalMin = 1;
    private const int CanalMax = 520;
    private int canalAtual;
    private int ultimoCanal;

    private const int VolumeMin = 0;
    private const int VolumeMax = 100;
    private int volumeAtual;
    private bool mudoAtivo;

    public Televisao()
    {
        canalAtual = CanalMin;
        volumeAtual = 50;
        mudoAtivo = false;
    }

    public int CanalAtual => canalAtual;
    public int VolumeAtual => mudoAtivo ? 0 : volumeAtual;

    public void MudarPara(int canal)
    {
        if (canal < CanalMin || canal > CanalMax)
        {
            Console.WriteLine($"Canal {canal} inválido! A TV suporta apenas de {CanalMin} até {CanalMax}.");
            return;
        }

        ultimoCanal = canalAtual;
        canalAtual = canal;
        Console.WriteLine($"Canal alterado para {canalAtual}.");
    }

    public void Proximo()
    {
        ultimoCanal = canalAtual;
        canalAtual = canalAtual >= CanalMax ? CanalMin : canalAtual + 1;
        Console.WriteLine($"Canal alterado para {canalAtual}.");
    }

    public void Anterior()
    {
        ultimoCanal = canalAtual;
        canalAtual = canalAtual <= CanalMin ? CanalMax : canalAtual - 1;
        Console.WriteLine($"Canal alterado para {canalAtual}.");
    }

    public void Desligar()
    {
        ultimoCanal = canalAtual;
        Console.WriteLine($"TV desligada. Último canal assistido: {ultimoCanal}");
    }

    public void Ligar()
    {
        canalAtual = ultimoCanal == 0 ? CanalMin : ultimoCanal;
        Console.WriteLine($"TV ligada no canal {canalAtual}, volume {VolumeAtual}.");
    }

    public void AumentarVolume()
    {
        if (mudoAtivo)
        {
            mudoAtivo = false;
            Console.WriteLine("Mudo desativado.");
        }

        if (volumeAtual < VolumeMax)
        {
            volumeAtual++;
            Console.WriteLine($"Volume: {volumeAtual}");
        }
        else
        {
            Console.WriteLine("Volume já está no máximo!");
        }
    }

    public void DiminuirVolume()
    {
        if (mudoAtivo)
        {
            mudoAtivo = false;
            Console.WriteLine("Mudo desativado.");
        }

        if (volumeAtual > VolumeMin)
        {
            volumeAtual--;
            Console.WriteLine($"Volume: {volumeAtual}");
        }
        else
        {
            Console.WriteLine("Volume já está no mínimo!");
        }
    }

    public void AtivarMudo()
    {
        mudoAtivo = !mudoAtivo;
        Console.WriteLine(mudoAtivo ? "Mudo ativado." : $"Mudo desativado. Volume: {volumeAtual}");
    }

    // Novos métodos para volume máximo e mínimo
    public void DefinirVolumeMaximo()
    {
        mudoAtivo = false;
        volumeAtual = VolumeMax;
        Console.WriteLine($"Volume definido para o máximo: {volumeAtual}");
    }

    public void DefinirVolumeMinimo()
    {
        mudoAtivo = false;
        volumeAtual = VolumeMin;
        Console.WriteLine($"Volume definido para o mínimo: {volumeAtual}");
    }
}

class Program
{
    static void Main()
    {
        Televisao tv = new Televisao();
        bool ligado = false;
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\n--- MENU DA TV ---");
            Console.WriteLine("1 - Ligar TV");
            Console.WriteLine("2 - Desligar TV");
            Console.WriteLine("3 - Próximo canal");
            Console.WriteLine("4 - Canal anterior");
            Console.WriteLine("5 - Ir para um canal específico");
            Console.WriteLine("6 - Ver canal atual");
            Console.WriteLine("7 - Aumentar volume");
            Console.WriteLine("8 - Diminuir volume");
            Console.WriteLine("9 - Ativar/Desativar Mudo");
            Console.WriteLine("10 - Ver volume atual");
            Console.WriteLine("11 - Definir volume para máximo (100)");
            Console.WriteLine("12 - Definir volume para mínimo (0)");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    if (!ligado)
                    {
                        tv.Ligar();
                        ligado = true;
                    }
                    else
                    {
                        Console.WriteLine("A TV já está ligada.");
                    }
                    break;

                case "2":
                    if (ligado)
                    {
                        tv.Desligar();
                        ligado = false;
                    }
                    else
                    {
                        Console.WriteLine("A TV já está desligada.");
                    }
                    break;

                case "3":
                    if (ligado) tv.Proximo();
                    else Console.WriteLine("Ligue a TV primeiro!");
                    break;

                case "4":
                    if (ligado) tv.Anterior();
                    else Console.WriteLine("Ligue a TV primeiro!");
                    break;

                case "5":
                    if (ligado)
                    {
                        Console.Write("Digite o número do canal: ");
                        if (int.TryParse(Console.ReadLine(), out int canal))
                        {
                            tv.MudarPara(canal);
                        }
                        else
                        {
                            Console.WriteLine("Número inválido!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ligue a TV primeiro!");
                    }
                    break;

                case "6":
                    if (ligado)
                    {
                        Console.WriteLine($"Canal atual: {tv.CanalAtual}");
                    }
                    else
                    {
                        Console.WriteLine("A TV está desligada.");
                    }
                    break;

                case "7":
                    if (ligado) tv.AumentarVolume();
                    else Console.WriteLine("Ligue a TV primeiro!");
                    break;

                case "8":
                    if (ligado) tv.DiminuirVolume();
                    else Console.WriteLine("Ligue a TV primeiro!");
                    break;

                case "9":
                    if (ligado) tv.AtivarMudo();
                    else Console.WriteLine("Ligue a TV primeiro!");
                    break;

                case "10":
                    if (ligado) Console.WriteLine($"Volume atual: {tv.VolumeAtual}");
                    else Console.WriteLine("A TV está desligada.");
                    break;

                case "11":
                    if (ligado) tv.DefinirVolumeMaximo();
                    else Console.WriteLine("Ligue a TV primeiro!");
                    break;

                case "12":
                    if (ligado) tv.DefinirVolumeMinimo();
                    else Console.WriteLine("Ligue a TV primeiro!");
                    break;

                case "0":
                    sair = true;
                    Console.WriteLine("Saindo do sistema da TV...");
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
