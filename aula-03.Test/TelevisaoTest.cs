using aula_03;

namespace aula_03.Test;

[TestClass]
public class TelevisaoTest
{
    [TestMethod]
    public void Dado_Tamanho_21_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(21f), $"O tamanho(21) n�o � suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_81_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(81f), $"O tamanho(81) n�o � suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_25_Deve_Criar_Instancia()
    {
        const float tamanho = 25f;

        Televisao televisao = new Televisao(tamanho);
        Assert.IsInstanceOfType(televisao, typeof(Televisao));
        Assert.AreEqual(tamanho, televisao.Tamanho);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Volume_10()
    {
        const int volumePadrao = 10;

        Televisao televisao = new Televisao(25f);
        Assert.AreEqual(volumePadrao, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_11_Apos_Aumentar_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AumentarVolume();
        Assert.AreEqual(11, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_09_Apos_Diminuir_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.DiminuirVolume();
        Assert.AreEqual(09, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_0_Ao_Mutar()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AlternarModoMudo();
        Assert.AreEqual(0, televisao.Volume);
    }


    [TestMethod]
    public void Deve_Restaurar_Volume_Anterior_Ao_Desmutar()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        televisao.AlternarModoMudo(); // Desmuta

        Assert.AreEqual(volumeInicial, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Estado_Correto_Com_Multiplas_Alternancias_Mudo()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo(); // Desmuta
        Assert.AreEqual(volumeInicial, televisao.Volume);

        televisao.AlternarModoMudo(); // Muta novamente
        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ignorar_Mudancas_Volume_Durante_Mudo()
    {
        Televisao televisao = new Televisao(25f);

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();
        televisao.DiminuirVolume();

        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Mudo_Ao_Tentar_Alterar_Volume()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();

        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo();
        Assert.AreEqual(volumeInicial, televisao.Volume);
    }


    //Testes abaixo foram criados para os pedidos da aula

    //Testes para o metodo "Aumentar e diminuir canal"

        [TestMethod]
    public void Deve_Aumentar_Canal()
    {
        Televisao televisao = new Televisao(25f);
        televisao.Canal = 10; // canal atual

        televisao.AumentarCanal();

        Assert.AreEqual(11, televisao.Canal);
    }

    [TestMethod]
    public void Deve_Diminuir_Canal()
    {
        Televisao televisao = new Televisao(25f);
        televisao.Canal = 10; // canal atual

        televisao.DiminuirCanal();

        Assert.AreEqual(9, televisao.Canal);
    }

    [TestMethod]
    public void Nao_Deve_Passar_Do_Canal_Maximo()
    {
        Televisao televisao = new Televisao(25f);
        televisao.Canal = 100; // no máximo

        televisao.AumentarCanal();

        Assert.AreEqual(100, televisao.Canal);
    }

    [TestMethod]
    public void Nao_Deve_Abaixar_Do_Canal_Minimo()
    {
        Televisao televisao = new Televisao(25f);
        televisao.Canal = 1; // no mínimo

        televisao.DiminuirCanal();

        Assert.AreEqual(1, televisao.Canal);
    }

    //Testes para o metodo "Selecionar canal pelo numero"
        [TestMethod]
    public void Deve_Selecionar_Canal_Pelo_Numero()
    {
        Televisao televisao = new Televisao(25f);

        televisao.SelecionarCanal(55);

        Assert.AreEqual(55, televisao.Canal);  // Espera que o canal seja 505
    }

    [TestMethod]
    public void Nao_Deve_Selecionar_Canal_Abaixo_Do_Minimo()
    {
        Televisao televisao = new Televisao(25f);

        televisao.SelecionarCanal(0);  // Tentando selecionar um canal abaixo do mínimo

        Assert.AreEqual(1, televisao.Canal);  // O canal não deve ser alterado, deve continuar sendo 1
    }

    [TestMethod]
    public void Nao_Deve_Selecionar_Canal_Acima_Do_Maximo()
    {
        Televisao televisao = new Televisao(25f);

        televisao.SelecionarCanal(1000);  // Tentando selecionar um canal acima do máximo

        Assert.AreEqual(1, televisao.Canal);  // O canal não deve ser alterado, deve continuar sendo 1
    }

    
}