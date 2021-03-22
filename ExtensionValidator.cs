  public static class Extentions
    {

        /// <summary>
        public static string RetornaDDD(this string numero)
        {
            try
            {
                return numero.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Substring(0, 2);
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string ToMaskCnpj(this string cnpj)
        {
            string _cnpj = string.Empty;
            long nCnpj = 0;
            try
            {
                nCnpj = Convert.ToInt64(cnpj);
                return _cnpj = string.Format(@"{0:00\.000\.000\/0000\-00}", nCnpj);
            }
            catch (Exception)
            {
                return _cnpj;
            }
        }

        public static string ToMaskCpf(this string cpf)
        {
            string _cpf = string.Empty;
            long ncpf = 0;
            try
            {
                ncpf = Convert.ToInt64(cpf);
                return _cpf = string.Format(@"{0:000\.000\.000\-00}", ncpf);
            }
            catch (Exception)
            {
                return _cpf;
            }
        }

        public static string NoMaskCnpj(this string cnpj)
        {
            try
            {
                return cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string RetornaTelefoneSemDDD(this string numero)            
        {
            try
            {
                return numero.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Substring(2);
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string RetornaTelefoneMask(string DDD, string telefone)
        {
            return "("+DDD+") " + telefone;
        }


        /// <summary>
        /// VALIDA CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool ValidaCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
        public static bool ValidaNrCPF(string vrCPF)

        {

            string valor = vrCPF.Replace(".", "");

            valor = valor.Replace("-", "");



            if (valor.Length != 11)

                return false;



            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;



            if (igual || valor == "12345678909")

                return false;



            int[] numeros = new int[11];



            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());



            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];



            int resultado = soma % 11;



            if (resultado == 1 || resultado == 0)

            {

                if (numeros[9] != 0)

                    return false;

            }

            else if (numeros[9] != 11 - resultado)

                return false;



            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];



            resultado = soma % 11;



            if (resultado == 1 || resultado == 0)

            {

                if (numeros[10] != 0)

                    return false;

            }

            else

                if (numeros[10] != 11 - resultado)

                return false;



            return true;

        }

        /// <summary>
        /// VALIDA CNPJ
        /// </summary>
        /// <param name="vrCNPJ"></param>
        /// <returns></returns>
        public static bool ValidaCNPJ(string vrCNPJ)
        {
            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");

            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(
                        CNPJ.Substring(nrDig, 1));

                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] *
                          int.Parse(ftmt.Substring(
                          nrDig + 1, 1)));

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] *
                          int.Parse(ftmt.Substring(
                          nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (
                         resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == (
                        11 - resultado[nrDig]));
                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }

        public static string DataFormatada(this DateTime dt)
        {
            if (dt != DateTime.MinValue)
                return dt.ToShortDateString();
            return string.Empty;

        }

        public static string ValorDecimalFormatado(this decimal valor)
        {
            if (valor > 0)
                return valor.ToString("C", CultureInfo.CurrentUICulture);
            return string.Empty;
        }
    }
}
