﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using BusinessLogicLayer;
using System.Text;

namespace BusinessLogicLayer
{
    public class BLL1
    {
        public class Refeicao
        {
            static public object loadpic()
            {
                DAL dal = new DAL();
                 SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", 1),
             };
                return dal.executarScalar("select Img from Imagem where id=1", sqlParams);
            
            }
            static public int insertPedido(string Cliente, string Nome_ref, int quantidade, double Precot,DateTime data)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Cliente", Cliente),
                new SqlParameter("@Nome_ref", Nome_ref),
                 new SqlParameter("@quantidade", quantidade),
                 new SqlParameter("@Precot", Precot),
                  new SqlParameter("@data", data),
            };
                return dal.executarNonQuery("INSERT into Pedidos (Cliente,Nome_ref,quantidade,Precot,data) VALUES (@Cliente,@Nome_ref,@quantidade,@Precot,data)", sqlParams);
            }
            static public int insertPacks(string nome, string prato, string sobremesa,byte[]foto,double preco)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome),
                new SqlParameter("@prato", prato),
                new SqlParameter("@sobremesa", sobremesa),
                new SqlParameter("@foto", foto),
                 new SqlParameter("@preco", preco),
            };
                return dal.executarNonQuery("INSERT into packs (nome,prato,sobremesa,foto,preco) VALUES (@nome,@prato,@sobremesa,@foto,@preco)", sqlParams);
            }

            static public DataTable loadRefeições()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Refeiçoes", null);
            }
            static public DataTable loadPacks()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from packs", null);
            }

            static public DataTable loadRefs(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                };
                return dal.executarReader("select * from Refeiçoes where Id_refeicao=@id", sqlParams);
            }

            static public int insertRefeições(string Nome,string TipodeRefeição, int Calorias, Decimal Lípidos, Decimal Carboidratos, Decimal Proteínas,byte[]foto,double preco )
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Nome",Nome),
                new SqlParameter("@TipodeRefeição",TipodeRefeição),
                new SqlParameter("@Calorias", Calorias),
                new SqlParameter("@Lípidos", Lípidos),
                new SqlParameter("@Carboidratos", Carboidratos),
                new SqlParameter("@Proteínas", Proteínas),
                new SqlParameter("@foto", foto),
                new SqlParameter("@preco", preco),
           };

                return dal.executarNonQuery("INSERT into Refeiçoes (Nome,TipodeRefeição,Calorias,Lípidos,Carboidratos,Proteínas,foto,preco) VALUES(@Nome,@TipodeRefeição,@Calorias,@Lípidos,@Carboidratos,@Proteínas,@foto,@preco)", sqlParams);
            }
            static public int updatePacks(int Id, string Nome, string prato, string sobremesa, byte[]foto,double preco)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Id", Id),
                new SqlParameter("@nome",Nome),
                new SqlParameter("@prato",prato),
                new SqlParameter("@sobremesa",sobremesa),
                new SqlParameter("@foto",foto),
                new SqlParameter("@preco",preco),

            };
                return dal.executarNonQuery("update [packs] set [nome]=@nome, [prato]=@prato, [sobremesa]=@sobremesa, [foto]=@foto, [preco]=@preco where [id_pack]=@Id", sqlParams);
            }
            static public int updateRefeições(int ID, string Nome, string TipodeRefeição, int Calorias, Decimal Lípidos, Decimal Carboidratos, Decimal Proteínas, byte[]foto,double preco)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID", ID),
                new SqlParameter("@Nome",Nome),
                new SqlParameter("@TipodeRefeição",TipodeRefeição),
                new SqlParameter("@Calorias", Calorias),
                new SqlParameter("@Lípidos", Lípidos),
                new SqlParameter("@Carboidratos", Carboidratos),
                new SqlParameter("@Proteínas", Proteínas),
                new SqlParameter("@foto",foto),
                new SqlParameter("@preco",preco),
            };
                return dal.executarNonQuery("update [Refeiçoes] set [Nome]=@Nome, [TipodeRefeição]=@TipodeRefeição, [Calorias]=@Calorias, [Lípidos]=@Lípidos, [Carboidratos]=@Carboidratos, [Proteínas]=@Proteínas,[foto]=@foto,[preco]=@preco where [id_refeicao]=@ID", sqlParams);
            }
            static public int deleteRefeições(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),

            };
                return dal.executarNonQuery("Delete From Refeiçoes WHERE[id_refeicao]=@id", sqlParams);
            }
            static public int deletePacks(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),

            };
                return dal.executarNonQuery("Delete From packs WHERE[id_pack]=@id", sqlParams);
            }
        }


        public class Resultados
        {
            static public Object queryimc()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                

                };
                return dal.executarScalar("select avg (imc) from Resultado where imc>18", sqlParams);
            }
            static public Object queryidade()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{


                };
                return dal.executarScalar("select avg (idade) from Pessoa", sqlParams);
            }
            static public Object queryquestionário()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{


                };
                return dal.executarScalar("select avg (Questionário) from Resultado", sqlParams);
            }
        }
            public class Logins
        {
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Login", null);
            }
            static public int insertLogin(string password, string usuario, bool adm)
            {
               
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@password", password),
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@adm", adm),



           };
                return dal.executarNonQuery("INSERT into Login (password,usuario,adm) VALUES(@password,@usuario,@adm)", sqlParams);
            }
            static public int updateLogin(string usuario,string password,bool adm)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@password",password),
                new SqlParameter("@adm",adm),
            };
                return dal.executarNonQuery("update [Login] set [usuario]=@usuario, [password]=@password, [adm]=@adm where [usuario]=@usuario", sqlParams);
            }
            static public int updateFunc(int NºFuncionario,string Nome, string Telefone, string Email, string NIF, string Morada, string Usuario,bool estado)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@NºFuncionario",NºFuncionario ),
                new SqlParameter("@Nome", Nome),
                new SqlParameter("@Telefone", Telefone),
                new SqlParameter("@Email", Email),
                new SqlParameter("@NIF", NIF),
                new SqlParameter("@Morada", Morada),
                new SqlParameter("@usuario", Usuario),
                new SqlParameter("@estado", estado),
            };
                return dal.executarNonQuery("update [Funcionário] set [Nome]=@Nome, [Telefone]=@Telefone, [Email]=@Email,[NIF]=@NIF,[Morada]=@Morada,[estado]=@estado where [NºFuncionario]=@NºFuncionario", sqlParams);
            }

            static public int insertFuncionario(string Nome, string Telefone, string Email, string NIF, string Morada, string Usuario)
            {
                
                 DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Nome", Nome),
                new SqlParameter("@Telefone", Telefone),
                new SqlParameter("@Email", Email),
                new SqlParameter("@NIF", NIF),
                new SqlParameter("@Morada", Morada),
                new SqlParameter("@usuario", Usuario),

           };
                return dal.executarNonQuery("INSERT into Funcionário (Nome,Telefone,Email,NIF,Morada,Usuario) VALUES(@Nome,@Telefone,@Email,@NIF,@Morada,@Usuario)", sqlParams);
            }


            static public DataTable Selectresults(String nome)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome + "%")
                };
                return dal.executarReader("select * from Clientes where Nome like @nome", sqlParams);
            }
            static public DataTable queryCliente(int id) {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }
            static public DataTable queryFunc()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                
                };
                return dal.executarReader("select * from Funcionário ", sqlParams);
            }
                static public DataTable queryLogin(string password, string usuario)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@password", password),
                
                };
                return dal.executarReader("select * from Login where usuario=@usuario and password=@password   ", sqlParams);
            }
            static public DataTable queryLoad()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
               

                };
                return dal.executarReader("select * from Login ", sqlParams);
            }
            static public DataTable queryUser(string usuario)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                 new SqlParameter("@usuario", usuario),
                };
                return dal.executarReader("select * from Login where usuario=@usuario ", sqlParams);
            }


        }

        static public DataTable queryCliente_3(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }
            static public int updateCliente(string id, string nome, string morada, string telefone)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                new SqlParameter("@nome", nome),
                new SqlParameter("@morada", morada),
                new SqlParameter("@telefone", telefone)
            };
                return dal.executarNonQuery("update [Clientes] set [nome]=@nome, [morada]=@morada, [telefone]=@telefone where [id]=@id", sqlParams);
            }
            static public int deleteCliente(string id)            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
               
            };
                return dal.executarNonQuery("Delete From Clientes WHERE[id]=@id", sqlParams);
            }
                static public int alterarPerfil(string utilizador, String password, string imagem)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@password", password),
                    new SqlParameter("@imagem", imagem)};

                return dal.executarNonQuery("update [utilizadores] set [password]=@password, [imagem]=@imagem where [utilizador]=@utilizador", sqlparams);
            }

            static public int alterarEstado(string utilizador, int estado)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@estado", estado)};

                return dal.executarNonQuery("update utilizadores set estado=@estado where utilizador=@utilizador", sqlparams);
            }

        }
    }
