namespace C_
{
    class Alimento
    {
        private int gramos_de_proteina;
        private int calorias;
        private string nombre;
        
        public Alimento(string nombre,int gramos_de_proteina,int calorias)
        {
            this.nombre = nombre;
            this.gramos_de_proteina = gramos_de_proteina;
            this.calorias = calorias;

        }
    

        public int Gramos_de_proteina
        {
            get
            {
                return gramos_de_proteina;
            }
            set
            {
                gramos_de_proteina = value;
            }
        }

        public int Calorias
        {
            get
            {
                return calorias;
            }
            set
            {
                calorias = value;
            }
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        

        
        
    }
}
