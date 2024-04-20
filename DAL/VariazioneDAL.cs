using Abbigliamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbigliamento.DAL
{
    internal class VariazioneDAL : Icrud<Variazione>
    {
        private static VariazioneDAL istanza;

        private VariazioneDAL() { }
        public static VariazioneDAL getIstanza()
        {
            if(istanza == null)
                istanza = new VariazioneDAL();
            return(istanza);
        }

        public bool CreateInsertValue(Variazione entity)
        {
            bool risultato = false;

            using (NegozioAbbigliamentoContext context = new NegozioAbbigliamentoContext())
            {
                try
                {
                    context.Variaziones.Add(entity);
                    context.SaveChanges();
                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return (risultato);
        }

        public bool DeleteValue(Variazione entity)
        {
            bool risultato = false;

            using (NegozioAbbigliamentoContext context = new NegozioAbbigliamentoContext())
            {
                try
                {
                    if (context.Variaziones.Contains(entity))
                    {
                        context.Variaziones.Remove(entity);
                        context.SaveChanges();
                        risultato = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return (risultato);
        }

        public List<Variazione> ReadGetValue()
        {
            List<Variazione> risposta = new List<Variazione>();
            using (NegozioAbbigliamentoContext context = new NegozioAbbigliamentoContext())
            {
                try
                {
                    risposta = context.Variaziones.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return (risposta);
        }

        public bool UpdateValue(Variazione entity)
        {
            bool risultato = false;

            using (NegozioAbbigliamentoContext context = new NegozioAbbigliamentoContext())
            {
                try
                {
                    var itemToRemove = context.Variaziones.SingleOrDefault(x => x.IdVariazione == entity.IdVariazione); //returns a single item.

                    if (itemToRemove != null)
                    {
                        context.Variaziones.Remove(itemToRemove);
                        context.Variaziones.Add(entity);
                        context.SaveChanges();
                        risultato = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return (risultato);
        }
    }
}
