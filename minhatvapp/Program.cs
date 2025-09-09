
using System;

public class Televisao
{
private const int CanalMin = 1;
private const int CanalMax = 520;
private int canalAtual;
private int ultimoCanal;

public Televisao()
{
canalAtual = CanalMin;
}

public int CanalAtual => canalAtual;

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
Console.WriteLine($"TV ligada no canal {canalAtual}.");
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
Console.WriteLine("0 - Sair");
Console.Write("Escolha uma opção: ");

string opcao = Console.ReadLine();
Console.WriteLine();

switch (opcao)
{
case "1":
tv.Ligar();
ligado = true;
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
Console.WriteLine("Entrada inválida! Digite um número.");
}
}
else
{
Console.WriteLine("Ligue a TV primeiro!");
}
break;
case "6":
if (ligado) Console.WriteLine($"Canal atual: {tv.CanalAtual}");
else Console.WriteLine("A TV está desligada.");
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