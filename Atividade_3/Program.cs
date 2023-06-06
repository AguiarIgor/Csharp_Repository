using Microsoft.Data.Sqlite;
using Aula10DB.Database;
using Aula10DB.Repositories;
using Aula10DB.Models;
var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var clienteRepository = new ClienteRepository(databaseConfig);
var pedidoRepository = new PedidoRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];
if(modelName == "Cliente")
{
    if(modelAction == "Listar")
    {
        int indicador = 1;
        Console.WriteLine("\nCliente Listar");
        foreach (var cliente in clienteRepository.Listar())
        {
            Console.WriteLine($"\n{indicador}º Registro\nCliente Id: {cliente.ClienteId}\nEndereço: {cliente.Endereco}\nCidade: {cliente.Cidade}\nRegião: {cliente.Regiao}\nCódigo Postal: {cliente.CodigoPostal}\nPaís: {cliente.Pais}\nTelefone: {cliente.Telefone}\n");
            ++indicador;
        }
        indicador = 0;
    }

    else if(modelAction == "Inserir")
    {
        Console.WriteLine("Cliente Inserir\n");
        Console.WriteLine("\nQual o Id: ");
        int clienteid = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\nQual o Endereço: ");
        string endereco = Console.ReadLine();
        Console.WriteLine("\nQual a Cidade: ");
        string cidade = Console.ReadLine();
        Console.WriteLine("\nQual a Região: ");
        string regiao = Console.ReadLine();
        Console.WriteLine("\nQual o Codigo Postal: ");
        string codigopostal = Console.ReadLine();
        Console.WriteLine("\nQual o País: ");
        string pais = Console.ReadLine();
        Console.WriteLine("\nQual o Telefone: ");
        string telefone = Console.ReadLine();
        var cliente = new Cliente(clienteid, endereco, cidade, regiao, codigopostal, pais, telefone);
        clienteRepository.Inserir(cliente);
    }
}

else if(modelName == "Pedido")
{
    if(modelAction == "Listar")
    {
        Console.WriteLine("\nPedido Listar");
        int indicador = 1;
        foreach (var pedido in pedidoRepository.Listar())
        {
            Console.WriteLine($"\n{indicador}º Registro\nId do Pedido: {pedido.PedidoId}\nId do Empregado{pedido.EmpregadoId}\nData: {pedido.DataPedido}\nPeso: {pedido.Peso}\nCódigo da Transportadora: {pedido.CodTransportadora}\nId do Cliente: {pedido.PedidoClienteId}\n");
            ++indicador;
        }
        indicador = 1;
    }

    else if(modelAction == "Inserir")
    {
        Console.WriteLine("Pedido Inserir\n");
        Console.WriteLine("\nQual o Id: ");
        int pedidoId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\nQual o Id do Empregado: ");
        int empregoId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\nQual a Data do Pedido: ");
        string dataPedido = Console.ReadLine();
        Console.WriteLine("\nQual o Peso do Pedido: ");
        string peso = Console.ReadLine();
        Console.WriteLine("\nQual o Código da Transportadora: ");
        int codTransportadora = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\nQual o Id do Cliente que fez o Pedido: ");
        int pedidoClienteId = Convert.ToInt32(Console.ReadLine());
        var pedido = new Pedido(pedidoId, empregoId, dataPedido, peso, codTransportadora, pedidoClienteId);
        pedidoRepository.Inserir(pedido);
    }
}
