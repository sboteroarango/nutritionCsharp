namespace C_
{
    class Persona
    {
        private string nombre;
        private int caloriasPersona;
        private int proteinaPersona;

        public Persona(string nombre)
        {
            this.nombre = nombre;
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

        public int ProteinaPersona
        {
            get
            {
                return proteinaPersona;
            }
            set
            {
                proteinaPersona = value;
            }
        }


        public int CaloriasPersona
        {
            get
            {
                return caloriasPersona;
            }
            set
            {
                caloriasPersona = value;
            }
        }
        public string Saludar()
        {
            return "hola mi nombre es " + nombre;
        }

        public void comer(Alimento alimento)
        {
            caloriasPersona = alimento.Calorias;
            proteinaPersona = alimento.Gramos_de_proteina;

        }
        
        public void hacerEjercicio(int horas){
            for (int i = 0; i < horas; i++)
            {
                caloriasPersona -= 100; 
                if(caloriasPersona<=0)
                {
                    break;

                }            
            }
        }
        
    }
}
