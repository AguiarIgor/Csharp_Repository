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
        Console.WriteLine("Id Cliente   Endereço do Cliente      Cidade      Região      Código Postal   País      Telefone");
        foreach (var cliente in clienteRepository.Listar())
        {
            Console.WriteLine($"{cliente.ClienteId, -12} {cliente.Endereco, -24} {cliente.Cidade, -11} {cliente.Regiao, -11} {cliente.CodigoPostal, -15} {cliente.Pais, -9} {cliente.Telefone}");
            ++indicador;
        }
        indicador = 0;
    }

    else if(modelAction == "Inserir")
    {
        Console.WriteLine("\nCliente Inserir");
        Console.WriteLine("Qual o Id: ");
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

    else if(modelAction == "Apresentar")
    {
        Console.WriteLine("\nCliente Apresentar");
        Console.WriteLine("Qual o Id do Cliente: ");
        int clienteid = Convert.ToInt32(Console.ReadLine());

        if(clienteRepository.Apresentar(clienteid))
        {
            var cliente = clienteRepository.GetById(clienteid);
            Console.WriteLine($"{cliente.ClienteId}, {cliente.Endereco}, {cliente.Cidade}, {cliente.Regiao}, {cliente.CodigoPostal}, {cliente.Pais}, {cliente.Telefone}");
        } 
        else 
        {
            Console.WriteLine($"O cliente com Id {clienteid} não existe.");
        }
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
            Console.WriteLine($"{pedido.PedidoId, -12} {pedido.EmpregadoId, -14} {pedido.DataPedido, -16} {pedido.Peso, -9} {pedido.CodTransportadora, -26} {pedido.PedidoClienteId}");
            ++indicador;
        }
        indicador = 1;
    }

    else if(modelAction == "Inserir")
    {
        Console.WriteLine("\nPedido Inserir");
        Console.WriteLine("Qual o Id: ");
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

    else if(modelAction == "Apresentar")
    {
        Console.WriteLine("\nPedido Apresentar");
        Console.WriteLine("Qual o Id do Pedido: ");
        int pedidoid = Convert.ToInt32(Console.ReadLine());

        if(pedidoRepository.Apresentar(pedidoid))
        {
            var pedido = pedidoRepository.GetById(pedidoid);
            Console.WriteLine($"{pedido.PedidoId}, {pedido.EmpregadoId}, {pedido.DataPedido}, {pedido.Peso}, {pedido.CodTransportadora}, {pedido.PedidoClienteId}");
        } 
        else 
        {
            Console.WriteLine($"O pedido com Id {pedidoid} não existe.");
        }
    }

    else if(modelAction == "MostrarPedidosCliente"){
        Console.WriteLine("\nPedido Mostrar Pedidos Cliente");
        Console.WriteLine("Qual o Id do Cliente: ");
        int clienteid = Convert.ToInt32(Console.ReadLine());

        if(pedidoRepository.MostrarPedidosCliente(clienteid))
        {
            foreach (var pedido in pedidoRepository.GetByClienteId(clienteid))
            {
                Console.WriteLine($"\nId do Pedido: {pedido.PedidoId}\nId do Empregado: {pedido.EmpregadoId}\nData: {pedido.DataPedido}\nPeso: {pedido.Peso}\nCódigo da Transportadora: {pedido.CodTransportadora}\n");
            }
        } 
        else 
        {
            Console.WriteLine($"O pedido com Id de cliente {clienteid} não existe.");
        }
    }
}
