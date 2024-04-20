using Abbigliamento.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbigliamento.DAL
{
    internal class ProdottoDAL : Icrud<Prodotto>
    {
        private static ProdottoDAL istanza;

        private ProdottoDAL() { }
        public ProdottoDAL getIstanza()
        {
            if(istanza == null)
                istanza = new ProdottoDAL();
            return istanza;
        }
        public bool CreateInsertValue(Prodotto entity)
        {
            bool risultato = false;

            using (NegozioAbbigliamentoContext context = new NegozioAbbigliamentoContext())
            {
                try
                {
                    context.Prodottos.Add(entity);
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

        public bool DeleteValue(Prodotto entity)
        {
            bool risultato = false;

            using (NegozioAbbigliamentoContext context = new NegozioAbbigliamentoContext())
            {
                try
                {
                    if (context.Prodottos.Contains(entity))
                    {
                        context.Prodottos.Remove(entity);
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

        public List<Prodotto> ReadGetValue()
        {
            List<Prodotto> risposta = new List<Prodotto>();
            using (NegozioAbbigliamentoContext context = new NegozioAbbigliamentoContext())
            {
                try
                {
                    risposta = context.Prodottos.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return (risposta);
        }

        public bool UpdateValue(Prodotto entity)
        {
            bool risultato = false;

            using (NegozioAbbigliamentoContext context = new NegozioAbbigliamentoContext())
            {
                try
                {
                    var itemToRemove = context.Prodottos.SingleOrDefault(x => x.IdProdotto == entity.IdProdotto); //returns a single item.

                    if (itemToRemove != null)
                    {
                        context.Prodottos.Remove(itemToRemove);
                        context.Prodottos.Add(entity);
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
