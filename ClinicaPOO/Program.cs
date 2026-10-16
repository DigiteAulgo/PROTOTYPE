using ClinicaPOO.Models;
using ClinicaPOO.Services;

Console.WriteLine("=== SISTEMA DA CLÍNICA VIDA & SAÚDE - PATTERN PROTOTYPE ===\n");

var gerenciador = new GerenciadorPrototipos();

// 1. CONFIGURAÇÃO DOS MODELOS BASE (Protótipos)
var checkupCardio = new PacoteExame("Check-up Cardiológico", "Jejum de 8h e evitar cafeína");
checkupCardio.AdicionarProcedimento(new Procedimento("Eletrocardiograma", 150.00m));
checkupCardio.AdicionarProcedimento(new Procedimento("Ecocardiograma", 350.00m));

gerenciador.CadastrarPrototipo("CARDIO_PADRAO", checkupCardio);

Console.WriteLine("--- Modelo Base Cadastrado ---");
checkupCardio.ExibirResumo();

// 2. USO CORRETO: Clonando via Cópia Profunda (Deep Copy)
Console.WriteLine("\n------------------------------------------------");
Console.WriteLine("--> Atendimento 1: Clonando com Clonar() [Deep Copy]");

var atendimento1 = gerenciador.ObterClone("CARDIO_PADRAO");
if (atendimento1 != null)
{
    atendimento1.NomePaciente = "Carlos Eduardo";
    atendimento1.AdicionarProcedimento(new Procedimento("Holter 24h", 250.00m));

    atendimento1.ExibirResumo();
}

// 3. DEMONSTRAÇÃO DO ERRO DA CÓPIA SUPERFICIAL (Shallow Copy)
Console.WriteLine("\n------------------------------------------------");
Console.WriteLine("--> Atendimento 2: Exemplo de Clonagem Superficial (Incorreta)");

var modeloOriginal = gerenciador.ObterClone("CARDIO_PADRAO");
if (modeloOriginal != null)
{
    var atendimentoErro = modeloOriginal.ClonarSuperficial();
    atendimentoErro.NomePaciente = "Ana Maria";
    atendimentoErro.AdicionarProcedimento(new Procedimento("Glicemia em Jejum", 30.00m));

    Console.WriteLine("\n[Atendimento da Ana Maria]:");
    atendimentoErro.ExibirResumo();

    Console.WriteLine("\n[VERIFICAÇÃO]: O Modelo Base também foi alterado indevidamente:");
    modeloOriginal.ExibirResumo();
}

// 4. CONFIRMAÇÃO DO ISOLAMENTO DO ATENDIMENTO 1
Console.WriteLine("\n------------------------------------------------");
Console.WriteLine("[VERIFICAÇÃO]: Atendimento 1 (Deep Copy) permaneceu intacto:");
atendimento1?.ExibirResumo();

Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey();