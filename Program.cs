using System;

namespace TesteFellipe
{
    class Program
    {
        public static void Main()
        {
            ExecutarQuestao1();
            ExecutarQuestao2();
            ExecutarQuestao3();
            ExecutarQuestao4();
            ExecutarQuestao5();
        }

        #region Questao_1

        static void ExecutarQuestao1()
        {
            int[] a = { 1, 2, 4 };
            int[] b = { 1, 2, 3, 4 };
            int[] c = { };
            int[] Invertido = Inverte(a);
            Console.WriteLine("QUESTAO 1: Testando entrada {1,2,4}:\n Resposta");

            for (int i = 0; i < Invertido.Length; i++)
            {
                Console.WriteLine(Invertido[i]);
            }
            Console.WriteLine("QUESTAO 1: Testando entrada { 1, 2, 3, 4 }:\n Resposta");

            Invertido = Inverte(b);
            for (int i = 0; i < Invertido.Length; i++)
            {
                Console.WriteLine(Invertido[i]);
            }
            Inverte(c);

            Console.WriteLine();
            Console.WriteLine("########################");
            Console.WriteLine();
        }

        static int[] Inverte(int[] X)
        {
            int[] invertido = new int[X.Length];
            int tamanho = X.Length;//Length retorna o tamanho do vetor
            int j = 0;
            for (int i = tamanho - 1; i >= 0; i--)//index começando do final
            {
                int temp = X[i];
                invertido[j] = X[i];
                j++;//index j para controlar o vetor a ser retornado
            }
            return invertido;
        }

        #endregion

        #region Questao_2

        static void ExecutarQuestao2()
        {
            Console.WriteLine("QUESTÃO 2: Testando para entrada 4: " + Fatorial(4));
            Console.WriteLine("QUESTÃO 2: Testando para entrada 5: " + Fatorial(5));
            Console.WriteLine("QUESTÃO 2: Testando para entrada 10: " + Fatorial(10));

            Console.WriteLine();
            Console.WriteLine("########################");
            Console.WriteLine();
        }

        static int Fatorial(int x)
        {
            if (x == 0 || x == 1)
            {
                return 1;
            }
            else
            {
                return x * Fatorial(x - 1);
            }
        }

        #endregion

        #region Questao_3

        static void ExecutarQuestao3()
        {
            Console.WriteLine($"QUESTÃO 3");
            Console.WriteLine();

            ListaEncadeada lista = new ListaEncadeada();

            lista.Adicionar(10);
            lista.Adicionar(20);
            lista.Adicionar(30);
            lista.Adicionar(40);

            lista.Adicionar(5);
            lista.Adicionar(15);
            lista.Adicionar(50);


            ImprimeListaEncadeada(lista);

            Console.WriteLine($"No Inicial: {lista.NoInicial.Valor}");
            Console.WriteLine($"No Final: {lista.NoFinal.Valor}");
            Console.WriteLine($"Removendo 40, 10 e 5");

            lista.Remover(40);
            lista.Remover(10);
            lista.Remover(5);

            ImprimeListaEncadeada(lista);

            Console.WriteLine($"No Inicial: {lista.NoInicial.Valor}");
            Console.WriteLine($"No Final: {lista.NoFinal.Valor}");

            Console.WriteLine();
            Console.WriteLine("########################");
            Console.WriteLine();
        }

        static void ImprimeListaEncadeada(ListaEncadeada lista)
        {
            Console.WriteLine("Imprimindo todos os itens da lista encadeada");

            No temp = lista.NoInicial;
            while (temp != null)
            {
                Console.Write(temp.Valor);
                Console.Write(" ");
                temp = temp.Proximo;
            }

            Console.WriteLine();
        }

        // classe que representa o nó da lista
        // Valor: int
        // PRoximo: representa a referencia para o próximo item da lista
        class No
        {
            public int Valor;
            public No Proximo = null;

            public override string ToString()
            {
                return Valor.ToString();
            }
        }

        class ListaEncadeada
        {
            public No NoInicial = null;

            /*
             * na lista ordenada
             * nao é preciso o uso do NoFinal
             * caso queira, ele pode ser removido
             */
            public No NoFinal = null;

            public void Adicionar(int valor)
            {
                // verifica se o nó inicial é vazio
                if (NoInicial == null)
                {
                    // cria um novo nó
                    No novo = new No();
                    novo.Valor = valor;
                    novo.Proximo = null;

                    // vincula ao nó inicial
                    NoInicial = novo;

                    // vincula ao nó final
                    NoFinal = novo;
                }
                else
                {
                    // cria um novo nó que será adicionado
                    No novo = new No();
                    novo.Valor = valor;
                    novo.Proximo = null;


                    if (valor < NoInicial.Valor)
                    {
                        // aponta o PRoximo do novo nó
                        // para o nó que era o nó inicial
                        No temp = NoInicial;
                        novo.Proximo = temp;
                        NoInicial = novo;
                    }
                    else
                    {
                        No temp = NoInicial;
                        // percorrendo todos os nós da lista
                        // até que chega no final 
                        while (temp.Proximo != null)
                        {
                            // verifica se o valor a ser adicionado
                            // é menor que o próximo nó da lista
                            if (valor < temp.Proximo.Valor)
                            {
                                novo.Proximo = temp.Proximo;
                                temp.Proximo = novo;
                                break;
                            }
                            temp = temp.Proximo;
                        }

                        // se chegou aqui, quer dizer que chegou no final da lista
                        // onde a variavel temp.PRoximo é igual a null
                        temp.Proximo = novo;
                        NoFinal = novo;
                    }
                }
            }

            public No Remover(int valor)
            {
                // verifica se o item removido é igual 
                if (NoInicial.Valor == valor)
                {
                    No temp = NoInicial;
                    NoInicial = temp.Proximo;
                    return temp;
                }
                else
                {
                    No temp = NoInicial;
                    // percorre os nós da lista até encontrar o nó desejado
                    while (temp.Proximo != null)
                    {
                        if (temp.Proximo.Valor == valor)
                        {
                            // armazena na variavel temporaria o nó que será removido
                            No noRemovido = temp.Proximo;

                            // verifica se o no a ser removido é o nó final
                            // se for o nó final, vamos alterar a referencia de NoFinal
                            if (noRemovido.Proximo == null)
                            {
                                NoFinal = temp;
                            }

                            // altera a referencia do próximo nó
                            // para o nó seguinte, removendo a refencia do item desejado
                            temp.Proximo = temp.Proximo.Proximo;

                            return noRemovido;
                        }

                        temp = temp.Proximo;
                    }

                    return null;
                }
            }
        }

        #endregion

        #region Questao_4

        static void ExecutarQuestao4()
        {
            int[] moda = { 3, 4, 3, 4, 4 };
            int[] moda2 = { 3, 4, 3, 4, 3 };
            Console.WriteLine("QUESTÃO 4: Testando para entrada { 3, 4, 3, 4, 4 }: " + Moda(moda));
            Console.WriteLine("QUESTÃO 4: Testando para entrada { 3, 4, 3, 4, 3 }: " + Moda(moda2));

            Console.WriteLine();
            Console.WriteLine("########################");
            Console.WriteLine();
        }

        static int Moda(int[] X)
        {
            int moda = 0;
            int maiorRepeticao = 0;
            int repeticaoAtual = 0;
            int tamanho = X.Length;
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = i + 1; j < tamanho; j++)
                {
                    if (X[i] == X[j])
                    {
                        repeticaoAtual++;
                    }
                    if (repeticaoAtual > maiorRepeticao)
                    {
                        maiorRepeticao = repeticaoAtual;
                        moda = X[i];
                    }

                }
                repeticaoAtual = 0;
            }
            return moda;
        }

        #endregion

        #region Questao_5

        static void ExecutarQuestao5()
        {
            int[,] A = new int[2, 3] { { 3, 5, 1 }, { 1, 7, 2 } };
            int[,] B = new int[3, 2] { { 1, 3 }, { 2, 4 }, { 1, 1 } };
            int[,] C = MultiplicaMatriz(A, B);

            string result = "";
            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    result += C[i, j].ToString() + " ";
                }
                result += "\n";
            }

            Console.WriteLine("QUESTÃO 5: Testando para entrada: A = { { 3, 5, 1 }, { 1, 7, 2 } }," +
                "B = { { 1, 3 }, { 2, 4 }, { 1, 1 } }; \n" + result);

            Console.WriteLine();
            Console.WriteLine("########################");
            Console.WriteLine();
        }

        static int[,] MultiplicaMatriz(int[,] A, int[,] B)
        {
            int linhaMatrizA = A.GetLength(0);//retorna primeiro dimensao da matriz
            int colunaMatrizA = A.GetLength(1);//retorna segunda dimensao da matriz
            int linhaMatrizB = B.GetLength(0);//retorna segunda dimensao da matriz
            int colunaMatrizB = B.GetLength(1);//retorna segunda dimensao da matriz
                                               //assim definimos o tamanho da matriz resultado
            int[,] resultado = new int[linhaMatrizA, colunaMatrizB];
            int somaProduto;
            for (int linha = 0; linha < linhaMatrizA; linha++)
            {
                for (int coluna = 0; coluna < colunaMatrizB; coluna++)
                {
                    somaProduto = 0;
                    for (int i = 0; i <= linhaMatrizA; i++)
                        somaProduto += A[linha, i] * B[i, coluna];
                    resultado[linha, coluna] = somaProduto;
                }
            }
            return resultado;
        }

        #endregion
    }
}