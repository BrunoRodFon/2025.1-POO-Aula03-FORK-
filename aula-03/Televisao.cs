namespace aula_03;

public class Televisao
{
    //O método construtor possui o mesmo nome da classe. 
    // Ele não possui retorno (nem mesmo o void)
    //Este método é executado sempre que uma instancia da classe
    //é criada.
    //Por padrão, o C# cria um método construtor publico vazio,
    //mas podemos criar métodos construtores com outras
    //visibilidades e recebendo parametros, se necessário.
    public Televisao(float tamanho)
    {
        if (tamanho < TAMANHO_MINIMO || tamanho > TAMANHO_MAXIMO)
        {
            throw new ArgumentOutOfRangeException($"O tamanho({tamanho}) não é suportado!");
        }
        Tamanho = tamanho;
        Volume = VOLUME_PADRAO;
        Canal = CANAL_MINIMO;  // Definindo o canal inicial como 1
    }


    //Optamos pela utilização da constante para tornar o código mais legível.
    private const float TAMANHO_MINIMO = 22;
    private const float TAMANHO_MAXIMO = 80;
    private const int VOLUME_MAXIMO = 12;
    private const int VOLUME_MINIMO = 0;
    private const int VOLUME_PADRAO = 10;

    //Constantes abaixos foram definidas para realizar os pedidos da aula
    private const int CANAL_MINIMO = 1;
    private const int CANAL_MAXIMO = 100;

    private int _ultimoVolume = VOLUME_PADRAO;



    //Get: permite que seja executada a 
    //leitura do valor atual da propriedade
    //Set: permite que seja atibuído um 
    //valor para a propriedade

    //classes, propriedades e métodos possuem modificadores de acesso
    //public: visiveis a todo o projeto
    //internal: visiveis somente no namespace - padrão
    //protected: visiveis somente na classe e nas classes que herdam
    //private: visiveis somente na classe que foram criados
    public float Tamanho { get; }
    public int Resolucao { get; set; }
    public int Volume { get; private set; }
    public int Canal { get; set; }
    public bool Estado { get; set; }

public void AumentarVolume()
{
    // Se estiver no mudo, não faz nada!
    if (Volume == VOLUME_MINIMO && _ultimoVolume != VOLUME_MINIMO)
    {
        Console.WriteLine("A TV está no modo MUTE. Não é possível aumentar o volume.");
        return;
    }

    if (Volume < VOLUME_MAXIMO)
    {
        Volume++;
        _ultimoVolume = Volume;
    }
    else
    {
        Console.WriteLine("A TV já está no volume máximo permitido");
    }
}

public void DiminuirVolume()
{
    // Se estiver no mudo, não faz nada!
    if (Volume == VOLUME_MINIMO && _ultimoVolume != VOLUME_MINIMO)
    {
        Console.WriteLine("A TV está no modo MUTE. Não é possível diminuir o volume.");
        return;
    }

    if (Volume > VOLUME_MINIMO)
    {
        Volume--;
        _ultimoVolume = Volume;
    }
    else
    {
        Console.WriteLine("A TV já está no volume mínimo permitido");
    }
}


    //1 botao de mudo -  toggle (on/off)
    //Volume = x; Volume = 0; Volume = x;
    public void AlternarModoMudo()
    {
        if (Volume > VOLUME_MINIMO)
        {
            _ultimoVolume = Volume;
            Volume = VOLUME_MINIMO;
            Console.WriteLine("A TV está no modo MUTE.");
        }
        else
        {
            Volume = _ultimoVolume;
            Console.WriteLine($"O volume da TV é: {Volume}.");
        }
    }


    // Novos metodos criados "AumentarCanal" e "Diminuir Canal"
        public void AumentarCanal()
    {
        if (Canal < CANAL_MAXIMO)
        {
            Canal++;
            Console.WriteLine($"Canal aumentado para {Canal}");
        }
        else
        {
            Console.WriteLine("Você já está no canal máximo.");
        }
    }

    public void DiminuirCanal()
    {
        if (Canal > CANAL_MINIMO)
        {
            Canal--;
            Console.WriteLine($"Canal diminuído para {Canal}");
        }
        else
        {
            Console.WriteLine("Você já está no canal mínimo.");
        }
    }

// Depois dos métodos AumentarCanal e DiminuirCanal

public void SelecionarCanal(int canal)
{
    if (canal < CANAL_MINIMO || canal > CANAL_MAXIMO)
    {
        Console.WriteLine($"O canal {canal} não está disponível.");
        // O canal não deve ser alterado se o valor for inválido
        return;
    }

    Canal = canal; // Altera o canal somente se o valor estiver dentro do intervalo válido
}





}

