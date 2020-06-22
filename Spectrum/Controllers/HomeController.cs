using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        int a, b, c, d, e, f, g, j, k, l, o, UPER, UPERCP, result_UPER = 0,
        SecRep = 0, SecRep1 = 0, SecRep2 = 0, /*SecRep3, SecRep4,*/ SecRep2a1 = 0, SecRep2a3 = 0, SecRep2a5 = 0, SecRep2a7 = 0, SecRep2a9 = 0;
        decimal SecRep2a2 = 0, SecRep2a4 = 0, SecRep2a6 = 0, SecRep2a8 = 0, SecRep2a10 = 0;
        int ThirdRep1a, ThirdRep1b, ThirdRep1c, ThirdRep1f, ThirdRep1g, ThirdRep1h;
        decimal ThirdRep1d, ThirdRep1e, ThirdRep1i, ThirdRep1j;
        int ThirdRepMedicaid3a;
        decimal ThirdRepMedicaid3b;
        int FourRep1a, FourRep1b, FourRep1c, FourRep1f, FourRep1g, FourRep1h;
        decimal FourRep1d, FourRep1e, FourRep1i, FourRep1j;
        int FourRepMedicaid4a;
        decimal FourRepMedicaid4b;

        int FiveRep1a, FiveRep1b, FiveRep1c, FiveRep1f, FiveRep1g, FiveRep1h;
        decimal FiveRep1d, FiveRep1e, FiveRep1i, FiveRep1j;
        int FiveRepMedicaid5a;
        decimal FiveRepMedicaid5b;


        decimal h, i, n, m, p, percent_UPERNCP, uper_float, upercp_float, result_UPER_float, percent_UPER = 0, SecRep1_float = 0, SecRep3_float = 0, SecRep4_float = 0;
        SqlConnection connectionString = new SqlConnection(@"Data Source=talhaserver.database.windows.net;Initial Catalog=sperctrum;Persist Security Info=True;User ID=demo;Password=Admin@123");
        //SqlConnection connectionString = new SqlConnection(@"Data Source =.; Initial Catalog = spectrum; Integrated Security = True");
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetYourReport()
        {
            return View();
        }
        public ActionResult Landing()
        {
            return View();
        }
        public ActionResult GetYourChart()
        {
            return View();
        }

        public ActionResult eReport()
        {
            return View("");
        }

        [HttpPost]
        public object result(string opts)
        {
            string[] terms = new string[17];

            connectionString.Open();
            if (opts.Equals("1"))
            {
                totalEscriptFill();
                totalEscriptFill_nonContracted();
                total_contractedPharma();
                totalEscriptFill_contracted();
                totalEscripts();
                totalEscriptFill_byNonCont();
                totalEscriptFill_byCont();
                PercNonContractedPharma();
                PercentContractedPharma();
                UniquePatients_EscriptRec();
                UniquePatients_EscriptRecConPharma();
                UniquePatients_EscriptRecNonConPharma();
                Perc_UniquePatients_EscriptRecCon();
                Perc_UniquePatients_EscriptNonRecCon();
                connectionString.Close();

                return Json(new { ESrx = new[] { new { ERxs1 = String.Format("{0:n0}", a) , ERxs2 = String.Format("{0:n0}", b), ERxs3 = String.Format("{0:n0}", c), ERxs4 = String.Format("{0:n0}", d) } }, Total = new[] { new { Total1 = String.Format("{0:n0}", e), Total2 = String.Format("{0:n0}", f), Total3 = String.Format("{0:n0}", g), Total4 = String.Format("{0:n0}", h) + "%", Total5 = String.Format("{0:n0}", i) + "%" } }, PatientProfile = new[] { new { pp1 = String.Format("{0:n0}", UPER), pp2 = String.Format("{0:n0}", UPERCP), pp3 = String.Format("{0:n0}", result_UPER_float), pp4 = percent_UPER + "%", pp5 = percent_UPERNCP + "%" } } }, JsonRequestBehavior.AllowGet);
            }
            else if (opts.Equals("2"))
            {
                totalEscripts();    // e
                totalEscriptInsuranceCovered();
                totalEscriptInsuranceCashCovered();
                totalEscriptInsuranceCoveredPer();
                totalEscriptInsuranceCashCoveredPer();

                //                totalEscripts();    // e
                totalERxSecReport2Mediacaid();
                totalERxSecReport2MediacaidPer();
                totalERxSecReport2Commercial();
                totalERxSecReport2CommercialPer();
                totalERxSecReport2Medicare();
                totalERxSecReport2MedicarePer();
                totalERxSecReport2Tricare();
                totalERxSecReport2TricarePer();
                totalERxSecReport2Cash();
                totalERxSecReport2CashPer();



                totalMCOMedicaid();
                totalMCO_Contracted();
                totalMCO_nonContracted();
                percentMCO_con();
                percentMCO_noncon();
                totalMCO_ContractedExcWalgreen();
                PerMCo_ExcWalgreen();

                connectionString.Close();

                return Json(new { EP = new[] { new { EP1 = String.Format("{0:n0}", SecRep), EP2 = String.Format("{0:n0}", SecRep1), EP3 = String.Format("{0:n0}", SecRep2), EP4 = Math.Round(SecRep3_float, 2) + "%", EP5 = Math.Round(SecRep4_float, 2) + "%" } }, EIC = new[] { new { EIC1 = String.Format("{0:n0}", SecRep), EIC2 = String.Format("{0:n0}", SecRep2a1), EIC3 = Math.Round(SecRep2a2, 2) + "%", EIC4 = String.Format("{0:n0}", SecRep2a3), EIC5 = Math.Round(SecRep2a4, 2) + "%", EIC6 = String.Format("{0:n0}", SecRep2a5), EIC7 = Math.Round(SecRep2a6, 2) + "%", EIC8 = String.Format("{0:n0}", SecRep2a7), EIC9 = Math.Round(SecRep2a8, 2) + "%", EIC10 = String.Format("{0:n0}", SecRep2a9), EIC11 = Math.Round(SecRep2a10, 2) + "%" } }, MCO = new[] { new { MCO1 = String.Format("{0:n0}", j), MCO2 = String.Format("{0:n0}", k), MCO3 = String.Format("{0:n0}", l), MCO4 = Math.Round(m,2) + "%", MCO5 = Math.Round(n,2) + "%", MCO6 = String.Format("{0:n0}", o), MCO7 = Math.Round(p,2) + "%" } } });
            }
            else if (opts.Equals("3"))
            {
                SqlDataReader Result = fetch3rdReport();
                if(Result.Read())
                {
                    ThirdRep1a = (int)Result[0];
                    ThirdRep1b = (int)Result[1];
                    ThirdRep1c = (int)Result[2];
                    ThirdRep1f = (int)Result[5];
                    ThirdRep1g = (int)Result[6];
                    ThirdRep1h = (int)Result[7];
                    ThirdRep1d = (decimal)Result[3];
                    ThirdRep1e = (decimal)Result[4];
                    ThirdRep1i = (decimal)Result[8];
                    ThirdRep1j = (decimal)Result[9];
                    ThirdRepMedicaid3a = (int)Result[10];
                    ThirdRepMedicaid3b = (decimal)Result[11];

                }
                Result.Close();
                /*
                TotalTargetDrugsReport3a();
                TotalTargetDrugsReport3b();
                TotalTargetDrugsReport3c();
                TotalTargetDrugsReport3d();
                TotalTargetDrugsReport3e();
                TotalTargetDrugsReport3f();
                TotalTargetDrugsReport3g();
                TotalTargetDrugsReport3h();
                TotalTargetDrugsReport3i();
                TotalTargetDrugsReport3j();

                TargetDrugMedicaidReport3a();
                TargetDrugMedicaidReport3b();
                */
                connectionString.Close();

                return Json(new { TTD = new[] { new { TTD1 = String.Format("{0:n0}", ThirdRep1a), TTD2 = String.Format("{0:n0}", ThirdRep1b), TTD3 = String.Format("{0:n0}", ThirdRep1c), TTD4 = Math.Round(ThirdRep1d, 2) + "%", TTD5 = Math.Round(ThirdRep1e, 2) + "%", TTD6 = String.Format("{0:n0}", ThirdRep1f), TTD7 = String.Format("{0:n0}", ThirdRep1g), TTD8 = String.Format("{0:n0}", ThirdRep1h), TTD9 = Math.Round(ThirdRep1i, 2) + "%", TTD10 = Math.Round(ThirdRep1j, 2) + "%" } }, TDMC = new[] { new { TDMC1 = String.Format("{0:n0}", ThirdRepMedicaid3a), TDMC2 = Math.Round(ThirdRepMedicaid3b, 2) + "%" } } });

            }
            else if (opts.Equals("4"))
            {
                /*
                                HivTargetDrugsReport3a();
                                HivTargetDrugsReport3b();
                                HivTargetDrugsReport3c();
                                HivTargetDrugsReport3d();
                                HivTargetDrugsReport3e();
                                HivTargetDrugsReport3f();
                                HivTargetDrugsReport3g();
                                HivTargetDrugsReport3h();
                                HivTargetDrugsReport3i();
                                HivTargetDrugsReport3j();

                                HivDrugMedicaidReport4a();
                                HivDrugMedicaidReport4b();
                */
                SqlDataReader Result = fetch4thReport();
                if (Result.Read())
                {
                    FourRep1a = (int)Result[0];
                    FourRep1b = (int)Result[1];
                    FourRep1c = (int)Result[2];
                    FourRep1f = (int)Result[5];
                    FourRep1g = (int)Result[6];
                    FourRep1h = (int)Result[7];
                    FourRep1d = (decimal)Result[3];
                    FourRep1e = (decimal)Result[4];
                    FourRep1i = (decimal)Result[8];
                    FourRep1j = (decimal)Result[9];
                    FourRepMedicaid4a = (int)Result[10];
                    FourRepMedicaid4b = (decimal)Result[11];

                }
                Result.Close();

                connectionString.Close();

                return Json(new { HIV = new[] { new { HIV1 = String.Format("{0:n0}", FourRep1a), HIV2 = String.Format("{0:n0}", FourRep1b), HIV3 = String.Format("{0:n0}", FourRep1c), HIV4 = Math.Round(FourRep1d, 2) + "%", HIV5 = Math.Round(FourRep1e, 2) + "%", HIV6 = String.Format("{0:n0}", FourRep1f), HIV7 = String.Format("{0:n0}", FourRep1g), HIV8 = String.Format("{0:n0}", FourRep1h), HIV9 = Math.Round(FourRep1i, 2) + "%", HIV10 = Math.Round(FourRep1j, 2) + "%" } }, HDMC = new[] { new { HDMC1 = String.Format("{0:n0}", FourRepMedicaid4a), HDMC2 = Math.Round(FourRepMedicaid4b, 2) + "%" } } });

            }
            else if (opts.Equals("5"))
            {
                /*
                                DibTargetDrugsReport3a();
                                DibTargetDrugsReport3b();
                                DibTargetDrugsReport3c();
                                DibTargetDrugsReport3d();
                                DibTargetDrugsReport3e();
                                DibTargetDrugsReport3f();
                                DibTargetDrugsReport3g();
                                DibTargetDrugsReport3h();
                                DibTargetDrugsReport3i();
                                DibTargetDrugsReport3j();

                                DibDrugMedicaidReport4a();
                                DibDrugMedicaidReport4b();
                */
                SqlDataReader Result = fetch5thReport();
                if (Result.Read())
                {
                    FiveRep1a = (int)Result[0];
                    FiveRep1b = (int)Result[1];
                    FiveRep1c = (int)Result[2];
                    FiveRep1f = (int)Result[5];
                    FiveRep1g = (int)Result[6];
                    FiveRep1h = (int)Result[7];
                    FiveRep1d = (decimal)Result[3];
                    FiveRep1e = (decimal)Result[4];
                    FiveRep1i = (decimal)Result[8];
                    FiveRep1j = (decimal)Result[9];
                    FiveRepMedicaid5a = (int)Result[10];
                    FiveRepMedicaid5b = (decimal)Result[11];

                }
                Result.Close();
                connectionString.Close();

                return Json(new { DDR = new[] { new { DDR1 = String.Format("{0:n0}", FiveRep1a), DDR2 = String.Format("{0:n0}", FiveRep1b), DDR3 = String.Format("{0:n0}", FiveRep1c), DDR4 = Math.Round(FiveRep1d, 2) + "%", DDR5 = Math.Round(FiveRep1e, 2) + "%", DDR6 = String.Format("{0:n0}", FiveRep1f), DDR7 = String.Format("{0:n0}", FiveRep1g), DDR8 = String.Format("{0:n0}", FiveRep1h), DDR9 = Math.Round(FiveRep1i, 2) + "%", DDR10 = Math.Round(FiveRep1j, 2) + "%" } }, TDMCDDR = new[] { new { TDMCDDR1 = String.Format("{0:n0}", FiveRepMedicaid5a), TDMCDDR2 = Math.Round(FiveRepMedicaid5b, 2) + "%" } } });

            }
            else if (opts.Equals("6"))
            {
                return Json(new {EQPTR = "True" });
            }
            else if (opts.Equals("7"))
            {
                var result =  PDCR_Detail();
                var result2 = PDCR_sum();
                return Json( new { PD = new[] { new { Patient_Detail = result } } , PS = new[] { new {PS = result2 } } });
            }
            else if (opts.Equals("9"))
            {
                var result = ORM_Details();
                var result2 = ORM_sum();
                return Json(new { ORMD = new[] { new { ORM_Detail = result } }, ORMS = new[] { new { ORMS = result2 } } });
            }
            else
            {
                connectionString.Close();
                return null;
            }
        }
        [HttpPost]
        public object totalEscriptFill()
        {

            string query = "select count(distinct pharmacy) from SpectrumEscriptData";
            var command = new SqlCommand(query, connectionString);
            int totalEscriptFill = (int)command.ExecuteScalar();
            a = totalEscriptFill;

            return Json(new { tef = totalEscriptFill }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public object totalEscriptFill_nonContracted()
        {

            string query = "select count(distinct pharmacy) from SpectrumEscriptData where pharmacy not in (select ActiveContractedPharmacies from ContractPharmaciesFillingExs where ActiveContractedPharmacies is not NULL)";
            var command = new SqlCommand(query, connectionString);
            int nonContracted = (int)command.ExecuteScalar();
            b = nonContracted;

            return Json(new { tef_nC = nonContracted }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public object total_contractedPharma()
        {

            string query = "select Count(distinct ActiveContractedPharmacies) from ContractPharmaciesFillingExs";
            var command = new SqlCommand(query, connectionString);
            int contractedPharma = (int)command.ExecuteScalar();
            c = contractedPharma;

            return Json(new { tef_C = contractedPharma }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public object totalEscriptFill_contracted()
        {

            string query = "select count(distinct ActiveContractedPharmacies) from ContractPharmaciesFillingExs where filling LIKE '%y%'";
            var command = new SqlCommand(query, connectionString);
            int Fill_contractedPharma = (int)command.ExecuteScalar();
            d = Fill_contractedPharma;

            return Json(new { tef_cf = Fill_contractedPharma }, JsonRequestBehavior.AllowGet);
        }
        int A = 0;
        [HttpPost]
        public object totalEscripts()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData";
            var command = new SqlCommand(query, connectionString);
            int Fill_contractedPharma = (int)command.ExecuteScalar();
            e = Fill_contractedPharma;
            A = e;
            SecRep = A;

            return Json(new { tef_cf = Fill_contractedPharma }, JsonRequestBehavior.AllowGet);
        }
        int B = 0;
        [HttpPost]
        public object totalEscriptFill_byNonCont()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData where pharmacy not in (select ActiveContractedPharmacies from ContractPharmaciesFillingExs where ActiveContractedPharmacies is not NULL)";
            var command = new SqlCommand(query, connectionString);
            int Fill_contractedPharma = (int)command.ExecuteScalar();
            f = Fill_contractedPharma;
            B = f;

            return Json(new { tef_cf = Fill_contractedPharma }, JsonRequestBehavior.AllowGet);
        }
        int C = 0, H = 0;
        [HttpPost]
        public object totalEscriptFill_byCont()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData where pharmacy in (select ActiveContractedPharmacies from ContractPharmaciesFillingExs where ActiveContractedPharmacies is not NULL)";
            var command = new SqlCommand(query, connectionString);
            int Fill_contractedPharma = (int)command.ExecuteScalar();
            g = Fill_contractedPharma;
            C = g;

            return Json(new { tef_cf = Fill_contractedPharma }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public object PercNonContractedPharma()
        {
            //
            //string query_A = "select count(distinct [order id]) from SpectrumEscriptData";
            //string query_B = "select count(distinct [order id]) from SpectrumEscriptData where pharmacy not in (select ActiveContractedPharmacies from ContractPharmaciesFillingExs where ActiveContractedPharmacies is not NULL)";

            //var command_A = new SqlCommand(query_A, connectionString);
            //int A = (int)command_A.ExecuteScalar();
            //var command_B = new SqlCommand(query_B, connectionString);
            //int B = (int)command_B.ExecuteScalar();
            //
            decimal perNonContracted = ((decimal)B / (decimal)A) * 100;
            h = (decimal)Math.Round(perNonContracted, 2);

            return Json(new { Perc_nonCon = perNonContracted }, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public object PercentContractedPharma()
        {
            //
            //string query_A = "select count(distinct [order id]) from SpectrumEscriptData";
            //string query_B = "select count(distinct [order id]) from SpectrumEscriptData where pharmacy in (select ActiveContractedPharmacies from ContractPharmaciesFillingExs where ActiveContractedPharmacies is not NULL)";

            //var command_A = new SqlCommand(query_A, connectionString);
            //int A = (int)command_A.ExecuteScalar();
            //var command_B = new SqlCommand(query_B, connectionString);
            //int B = (int)command_B.ExecuteScalar();

            //
            decimal perContracted = ((decimal)C / (decimal)A) * 100;
            i = (decimal)Math.Round(perContracted, 2);
            return Json(new { Perc_Con = perContracted }, JsonRequestBehavior.AllowGet);
        }
        int D = 0;
        [HttpPost]
        public object totalMCOMedicaid()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData where [insurance name] in (select [Payer Name] from PayerType where [Payer Type] = 'Medicaid')";
            var command = new SqlCommand(query, connectionString);
            int TotalMedicaid = (int)command.ExecuteScalar();

            j = TotalMedicaid;
            D = j;
            return Json(new { tm = TotalMedicaid }, JsonRequestBehavior.AllowGet);
        }
        int E = 0;
        [HttpPost]
        public object totalMCO_Contracted()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData where [insurance name] in (select [Payer Name] from PayerType where [Payer Type] = 'Medicaid') and pharmacy  in (select ActiveContractedPharmacies from ContractPharmaciesFillingExs where ActiveContractedPharmacies is not NULL)";
            var command = new SqlCommand(query, connectionString);
            int TotalMedicaid_contracted = (int)command.ExecuteScalar();
            k = TotalMedicaid_contracted;
            E = k;

            return Json(new { tm_Con = TotalMedicaid_contracted }, JsonRequestBehavior.AllowGet);
        }
        int F = 0;
        [HttpPost]
        public object totalMCO_nonContracted()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData where [insurance name] in (select [Payer Name] from PayerType where [Payer Type] = 'Medicaid') and pharmacy  not in (select ActiveContractedPharmacies from ContractPharmaciesFillingExs where ActiveContractedPharmacies is not NULL)";
            var command = new SqlCommand(query, connectionString);
            int TotalMedicaid_noncontracted = (int)command.ExecuteScalar();
            l = TotalMedicaid_noncontracted;
            F = l;

            return Json(new { tm_nonCon = TotalMedicaid_noncontracted }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public object percentMCO_con()
        {
            //
            //string query_A = "select count(distinct [order id]) from SpectrumEscriptData where [insurance name] in (select [Payer Name] from PayerType where [Payer Type] = 'Medicaid')";
            //string query_B = "select count(distinct [order id]) from SpectrumEscriptData where [insurance name] in (select [Payer Name] from PayerType where [Payer Type] = 'Medicaid') and pharmacy  in (select ActiveContractedPharmacies from ContractPharmaciesFillingExs where ActiveContractedPharmacies is not NULL)";

            //var command_A = new SqlCommand(query_A, connectionString);
            //int A = (int)command_A.ExecuteScalar();
            //var command_B = new SqlCommand(query_B, connectionString);
            //int B = (int)command_B.ExecuteScalar();
            //
            decimal perMCOContracted = ((decimal)E / (decimal)D) * 100;
            m = (decimal)Math.Round(perMCOContracted, 2);
            return Json(new { PercMCO_Con = perMCOContracted }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public object percentMCO_noncon()
        {
            //
            //string query_A = "select count(distinct [order id]) from SpectrumEscriptData where [insurance name] in (select [Payer Name] from PayerType where [Payer Type] = 'Medicaid')";
            //string query_B = "select count(distinct [order id]) from SpectrumEscriptData where [insurance name] in (select [Payer Name] from PayerType where [Payer Type] = 'Medicaid') and pharmacy  not in (select ActiveContractedPharmacies from ContractPharmaciesFillingExs where ActiveContractedPharmacies is not NULL)";

            //var command_A = new SqlCommand(query_A, connectionString);
            //int A = (int)command_A.ExecuteScalar();
            //var command_B = new SqlCommand(query_B, connectionString);
            //int B = (int)command_B.ExecuteScalar();
            //
            decimal perMCO_nonContracted = ((decimal)F / (decimal)D) * 100;
            n = (decimal)Math.Round(perMCO_nonContracted, 2);
            return Json(new { PercMCO_nonCon = perMCO_nonContracted }, JsonRequestBehavior.AllowGet);
        }
        int G = 0;
        [HttpPost]
        public object totalMCO_ContractedExcWalgreen()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData where [insurance name] in (select [Payer Name] from PayerType where [Payer Type] = 'Medicaid') and pharmacy  in (select ActiveContractedPharmacies from ContractPharmaciesFillingExs where ActiveContractedPharmacies is not NULL and CHAIN_NOT_FILLING_MCMO = 'N' and ChainPharmacy = 'y')";
            var command = new SqlCommand(query, connectionString);
            int TotalMedicaid_contracted = (int)command.ExecuteScalar();

            o = TotalMedicaid_contracted;
            G = o;
            return Json(new { tm_Con = TotalMedicaid_contracted }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object PerMCo_ExcWalgreen()
        {
            //
            //string query_A = "select count(distinct [order id]) from SpectrumEscriptData where [insurance name] in (select [Payer Name] from PayerType where [Payer Type] = 'Medicaid')";
            //string query_B = "select count(distinct [order id]) from SpectrumEscriptData where [insurance name] in (select [Payer Name] from PayerType where [Payer Type] = 'Medicaid') and pharmacy  in (select ActiveContractedPharmacies from ContractPharmaciesFillingExs where ActiveContractedPharmacies is not NULL and filling='N')";

            //var command_A = new SqlCommand(query_A, connectionString);
            //int A = (int)command_A.ExecuteScalar();
            //var command_B = new SqlCommand(query_B, connectionString);
            //int B = (int)command_B.ExecuteScalar();
            //
            decimal perMCO_excWalgreen = ((decimal)G / (decimal)D) * 100;
            p = (decimal)Math.Round(perMCO_excWalgreen, 2);
            return Json(new { perMCO_Walgreen = perMCO_excWalgreen }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public object UniquePatients_EscriptRec()
        {

            string query = "select Count(Distinct patientid) from SpectrumEscriptData";
            var command = new SqlCommand(query, connectionString);
            UPER = (int)command.ExecuteScalar();
            uper_float = (decimal)UPER;

            return Json(new { uper = UPER }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public object UniquePatients_EscriptRecConPharma()
        {

            string query = "select Count(Distinct patientid) from SpectrumEscriptData, ContractPharmaciesFillingExs where pharmacy = ActiveContractedPharmacies and filling like '%y%'";
            var command = new SqlCommand(query, connectionString);
            UPERCP = (int)command.ExecuteScalar();
            upercp_float = (decimal)UPERCP;

            return Json(new { uper = UPERCP }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public object UniquePatients_EscriptRecNonConPharma()
        {   //A-B
            result_UPER = UPER - UPERCP;
            result_UPER_float = (decimal)result_UPER;
            return Json(new { uper_result = result_UPER }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object Perc_UniquePatients_EscriptRecCon()
        {   //(B/A)*100
            decimal res_uper = (upercp_float / uper_float) * 100;
            percent_UPER = (decimal)Math.Round(res_uper, 2);
            return Json(new { uper_percentage = percent_UPER }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object Perc_UniquePatients_EscriptNonRecCon()
        {   //(C/A)*100
            decimal res_uoer = (result_UPER_float / uper_float) * 100;
            percent_UPERNCP = (decimal)Math.Round(res_uoer, 2);
            return Json(new { uper_percentage = percent_UPERNCP }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public object totalEscriptInsuranceCovered()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Cash'";
            var command = new SqlCommand(query, connectionString);
            SecRep1 = (int)command.ExecuteScalar();
            SecRep1_float = (decimal)SecRep1;

            return Json(new { uper = SecRep1 }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object totalEscriptInsuranceCashCovered()
        {
            SecRep2 = (A - SecRep1);
            return Json(new { uper = SecRep2 }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object totalEscriptInsuranceCoveredPer()
        {
            SecRep3_float = ((decimal)SecRep1 / (decimal)A) * 100;
            return Json(new { uper = SecRep3_float }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object totalEscriptInsuranceCashCoveredPer()
        {
            SecRep4_float = (decimal)100.00 - SecRep3_float;
            return Json(new { uper = SecRep4_float }, JsonRequestBehavior.AllowGet);
        }

        public object totalERxSecReport2Mediacaid()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Medicaid'";
            var command = new SqlCommand(query, connectionString);
            SecRep2a1 = (int)command.ExecuteScalar();
            //SecRep2a1_float = (decimal)SecRep2a1;

            return Json(new { uper = SecRep2a1 }, JsonRequestBehavior.AllowGet);
        }

        public object totalERxSecReport2Commercial()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Commercial'";
            var command = new SqlCommand(query, connectionString);
            SecRep2a3 = (int)command.ExecuteScalar();
            //SecRep2a3_float = (decimal)SecRep2a3;

            return Json(new { uper = SecRep2a3 }, JsonRequestBehavior.AllowGet);
        }

        public object totalERxSecReport2Medicare()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Medicare'";
            var command = new SqlCommand(query, connectionString);
            SecRep2a5 = (int)command.ExecuteScalar();
            //SecRep2a5_float = (decimal)SecRep2a5;

            return Json(new { uper = SecRep2a5 }, JsonRequestBehavior.AllowGet);
        }

        public object totalERxSecReport2Tricare()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Tricare'";
            var command = new SqlCommand(query, connectionString);
            SecRep2a7 = (int)command.ExecuteScalar();
            //SecRep2a7_float = (decimal)SecRep2a7;

            return Json(new { uper = SecRep2a7 }, JsonRequestBehavior.AllowGet);
        }

        public object totalERxSecReport2Cash()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Cash'";
            var command = new SqlCommand(query, connectionString);
            SecRep2a9 = (int)command.ExecuteScalar();
            //SecRep2a9_float = (decimal)SecRep2a9;

            return Json(new { uper = SecRep2a9 }, JsonRequestBehavior.AllowGet);
        }
        public object totalERxSecReport2MediacaidPer()
        {
            SecRep2a2 = ((decimal)SecRep2a1 / (decimal)A) * 100;
            return Json(new { uper = SecRep2a2 }, JsonRequestBehavior.AllowGet);
        }
        public object totalERxSecReport2CommercialPer()
        {
            SecRep2a4 = ((decimal)SecRep2a3 / (decimal)A) * 100;
            return Json(new { uper = SecRep2a4 }, JsonRequestBehavior.AllowGet);

        }
        public object totalERxSecReport2MedicarePer()
        {
            SecRep2a6 = ((decimal)SecRep2a5 / (decimal)A) * 100;
            return Json(new { uper = SecRep2a6 }, JsonRequestBehavior.AllowGet);

        }
        public object totalERxSecReport2TricarePer()
        {
            SecRep2a8 = ((decimal)SecRep2a7 / (decimal)A) * 100;
            return Json(new { uper = SecRep2a8 }, JsonRequestBehavior.AllowGet);

        }
        public object totalERxSecReport2CashPer()
        {
            SecRep2a10 = ((decimal)SecRep2a9 / (decimal)A) * 100;
            return Json(new { uper = SecRep2a10 }, JsonRequestBehavior.AllowGet);

        }

        public object TotalTargetDrugsReport3a()
        {

            string query = "select count(distinct[patientid]) from SpectrumEscriptData, TargetDrugList where[Drug name] like '%' + [Brand Tragetted Drug] + '%'";
            var command = new SqlCommand(query, connectionString);
            ThirdRep1a = (int)command.ExecuteScalar();
            A = ThirdRep1a;

            return Json(new { uper = ThirdRep1a }, JsonRequestBehavior.AllowGet);
        }
        public object TotalTargetDrugsReport3b()
        {

            string query = "select count(distinct[patientid]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs  where[Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies";
            var command = new SqlCommand(query, connectionString);
            ThirdRep1b = (int)command.ExecuteScalar();
            //SecRep2a9_float = (decimal)SecRep2a9;
            B = ThirdRep1b;

            return Json(new { uper = ThirdRep1b }, JsonRequestBehavior.AllowGet);
        }

        public object TotalTargetDrugsReport3c()
        {
            ThirdRep1c = A - B;
            C = ThirdRep1c;
            return Json(new { uper = ThirdRep1c }, JsonRequestBehavior.AllowGet);
        }
        public object TotalTargetDrugsReport3d()
        {
            ThirdRep1d = ((decimal)B / (decimal)A) * 100;
            return Json(new { uper = ThirdRep1d }, JsonRequestBehavior.AllowGet);
        }

        public object TotalTargetDrugsReport3e()
        {
            ThirdRep1e = ((decimal)C / (decimal)A) * 100;
            return Json(new { uper = ThirdRep1e }, JsonRequestBehavior.AllowGet);
        }


        public object TotalTargetDrugsReport3f()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList where [Drug name] like '%' + [Brand Tragetted Drug] + '%'";
            var command = new SqlCommand(query, connectionString);
            ThirdRep1f = (int)command.ExecuteScalar();
            F = ThirdRep1f;

            return Json(new { uper = ThirdRep1f }, JsonRequestBehavior.AllowGet);
        }
        public object TotalTargetDrugsReport3g()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs where [Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies";
            var command = new SqlCommand(query, connectionString);
            ThirdRep1g = (int)command.ExecuteScalar();
            G = ThirdRep1g;

            return Json(new { uper = ThirdRep1g }, JsonRequestBehavior.AllowGet);
        }

        public object TotalTargetDrugsReport3h()
        {
            ThirdRep1h = F - G;
            H = ThirdRep1h;
            return Json(new { uper = ThirdRep1h }, JsonRequestBehavior.AllowGet);
        }
        public object TotalTargetDrugsReport3i()
        {
            ThirdRep1i = ((decimal)G / (decimal)F) * 100;
            return Json(new { uper = ThirdRep1i }, JsonRequestBehavior.AllowGet);
        }

        public object TotalTargetDrugsReport3j()
        {
            ThirdRep1j = ((decimal)H / (decimal)F) * 100;
            return Json(new { uper = ThirdRep1j }, JsonRequestBehavior.AllowGet);
        }

        public object TargetDrugMedicaidReport3a()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs where[Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies and ChainPharmacy = 'Y' and CHAIN_NOT_FILLING_MCMO = 'N'";
            var command = new SqlCommand(query, connectionString);
            ThirdRepMedicaid3a = (int)command.ExecuteScalar();
            //F = ThirdRep1f;
            A = ThirdRepMedicaid3a;

            return Json(new { uper = ThirdRepMedicaid3a }, JsonRequestBehavior.AllowGet);
        }
        public object TargetDrugMedicaidReport3b()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs where [Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies and filling = 'Y'";
            var command = new SqlCommand(query, connectionString);
            ThirdRepMedicaid3b = (int)command.ExecuteScalar();
            //G = ThirdRep1g;
            ThirdRepMedicaid3b = ((decimal)A / (decimal)ThirdRepMedicaid3b) / 100;

            return Json(new { uper = ThirdRepMedicaid3b }, JsonRequestBehavior.AllowGet);
        }


        //4th report
        public object HivTargetDrugsReport3a()
        {

            string query = "select count(distinct[patientid]) from SpectrumEscriptData, TargetDrugList where TargetDrugList.Type = 'HIV' and [Drug name] like '%' + [Brand Tragetted Drug] + '%'";
            var command = new SqlCommand(query, connectionString);
            FourRep1a = (int)command.ExecuteScalar();
            A = FourRep1a;

            return Json(new { uper = FourRep1a }, JsonRequestBehavior.AllowGet);
        }
        public object HivTargetDrugsReport3b()
        {

            string query = "select count(distinct[patientid]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs  where TargetDrugList.Type = 'HIV' and [Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies";
            var command = new SqlCommand(query, connectionString);
            FourRep1b = (int)command.ExecuteScalar();
            //SecRep2a9_float = (decimal)SecRep2a9;
            B = FourRep1b;

            return Json(new { uper = FourRep1b }, JsonRequestBehavior.AllowGet);
        }

        public object HivTargetDrugsReport3c()
        {
            FourRep1c = A - B;
            C = FourRep1c;
            return Json(new { uper = FourRep1c }, JsonRequestBehavior.AllowGet);
        }
        public object HivTargetDrugsReport3d()
        {
            FourRep1d = ((decimal)B / (decimal)A) * 100;
            return Json(new { uper = FourRep1d }, JsonRequestBehavior.AllowGet);
        }

        public object HivTargetDrugsReport3e()
        {
            FourRep1e = ((decimal)C / (decimal)A) * 100;
            return Json(new { uper = FourRep1e }, JsonRequestBehavior.AllowGet);
        }


        public object HivTargetDrugsReport3f()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList where TargetDrugList.Type = 'HIV' and [Drug name] like '%' + [Brand Tragetted Drug] + '%'";
            var command = new SqlCommand(query, connectionString);
            FourRep1f = (int)command.ExecuteScalar();
            F = FourRep1f;

            return Json(new { uper = FourRep1f }, JsonRequestBehavior.AllowGet);
        }
        public object HivTargetDrugsReport3g()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs where TargetDrugList.Type = 'HIV' and [Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies";
            var command = new SqlCommand(query, connectionString);
            FourRep1g = (int)command.ExecuteScalar();
            G = FourRep1g;

            return Json(new { uper = FourRep1g }, JsonRequestBehavior.AllowGet);
        }

        public object HivTargetDrugsReport3h()
        {
            FourRep1h = F - G;
            H = FourRep1h;
            return Json(new { uper = FourRep1h }, JsonRequestBehavior.AllowGet);
        }
        public object HivTargetDrugsReport3i()
        {
            FourRep1i = ((decimal)G / (decimal)F) * 100;
            return Json(new { uper = FourRep1i }, JsonRequestBehavior.AllowGet);
        }

        public object HivTargetDrugsReport3j()
        {
            FourRep1j = ((decimal)H / (decimal)F) * 100;
            return Json(new { uper = FourRep1j }, JsonRequestBehavior.AllowGet);
        }

        public object HivDrugMedicaidReport4a()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs where TargetDrugList.Type = 'HIV' and [Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies and ChainPharmacy = 'Y' and CHAIN_NOT_FILLING_MCMO = 'N'";
            var command = new SqlCommand(query, connectionString);
            FourRepMedicaid4a = (int)command.ExecuteScalar();
            //F = FourRep1f;
            A = FourRepMedicaid4a;

            return Json(new { uper = FourRepMedicaid4a }, JsonRequestBehavior.AllowGet);
        }
        public object HivDrugMedicaidReport4b()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs where TargetDrugList.Type = 'HIV' and [Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies and filling = 'Y'";
            var command = new SqlCommand(query, connectionString);
            FourRepMedicaid4b = (int)command.ExecuteScalar();
            //G = FourRep1g;
            FourRepMedicaid4b = ((decimal)A / (decimal)FourRepMedicaid4b) * 100;

            return Json(new { uper = FourRepMedicaid4b }, JsonRequestBehavior.AllowGet);
        }



        //end of 4th report


        //start of 5th report
        public object DibTargetDrugsReport3a()
        {

            string query = "select count(distinct[patientid]) from SpectrumEscriptData, TargetDrugList where TargetDrugList.Type = 'DIB' and [Drug name] like '%' + [Brand Tragetted Drug] + '%'";
            var command = new SqlCommand(query, connectionString);
            FiveRep1a = (int)command.ExecuteScalar();
            A = FiveRep1a;

            return Json(new { uper = FiveRep1a }, JsonRequestBehavior.AllowGet);
        }
        public object DibTargetDrugsReport3b()
        {

            string query = "select count(distinct[patientid]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs  where TargetDrugList.Type = 'DIB' and [Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies";
            var command = new SqlCommand(query, connectionString);
            FiveRep1b = (int)command.ExecuteScalar();
            //SecRep2a9_float = (decimal)SecRep2a9;
            B = FiveRep1b;

            return Json(new { uper = FiveRep1b }, JsonRequestBehavior.AllowGet);
        }

        public object DibTargetDrugsReport3c()
        {
            FiveRep1c = A - B;
            C = FiveRep1c;
            return Json(new { uper = FiveRep1c }, JsonRequestBehavior.AllowGet);
        }
        public object DibTargetDrugsReport3d()
        {
            FiveRep1d = ((decimal)B / (decimal)A) * 100;
            return Json(new { uper = FiveRep1d }, JsonRequestBehavior.AllowGet);
        }

        public object DibTargetDrugsReport3e()
        {
            FiveRep1e = ((decimal)C / (decimal)A) * 100;
            return Json(new { uper = FiveRep1e }, JsonRequestBehavior.AllowGet);
        }


        public object DibTargetDrugsReport3f()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList where TargetDrugList.Type = 'DIB' and [Drug name] like '%' + [Brand Tragetted Drug] + '%'";
            var command = new SqlCommand(query, connectionString);
            FiveRep1f = (int)command.ExecuteScalar();
            F = FiveRep1f;

            return Json(new { uper = FiveRep1f }, JsonRequestBehavior.AllowGet);
        }
        public object DibTargetDrugsReport3g()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs where TargetDrugList.Type = 'DIB' and [Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies";
            var command = new SqlCommand(query, connectionString);
            FiveRep1g = (int)command.ExecuteScalar();
            G = FiveRep1g;

            return Json(new { uper = FiveRep1g }, JsonRequestBehavior.AllowGet);
        }

        public object DibTargetDrugsReport3h()
        {
            FiveRep1h = F - G;
            H = FiveRep1h;
            return Json(new { uper = FiveRep1h }, JsonRequestBehavior.AllowGet);
        }
        public object DibTargetDrugsReport3i()
        {
            FiveRep1i = ((decimal)G / (decimal)F) * 100;
            return Json(new { uper = FiveRep1i }, JsonRequestBehavior.AllowGet);
        }

        public object DibTargetDrugsReport3j()
        {
            FiveRep1j = ((decimal)H / (decimal)F) * 100;
            return Json(new { uper = FiveRep1j }, JsonRequestBehavior.AllowGet);
        }

        public object DibDrugMedicaidReport4a()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs where TargetDrugList.Type = 'DIB' and [Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies and ChainPharmacy = 'Y' and CHAIN_NOT_FILLING_MCMO = 'N'";
            var command = new SqlCommand(query, connectionString);
            FiveRepMedicaid5a = (int)command.ExecuteScalar();
            //F = FiveRep1f;
            A = FiveRepMedicaid5a;

            return Json(new { uper = FiveRepMedicaid5a }, JsonRequestBehavior.AllowGet);
        }
        public object DibDrugMedicaidReport4b()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, TargetDrugList, ContractPharmaciesFillingExs where TargetDrugList.Type = 'DIB' and [Drug name] like '%' + [Brand Tragetted Drug] + '%' and pharmacy = ActiveContractedPharmacies and filling = 'Y'";
            var command = new SqlCommand(query, connectionString);
            FiveRepMedicaid5b = (int)command.ExecuteScalar();
            //G = FiveRep1g;
            FiveRepMedicaid5b = ((decimal)A / (decimal)FiveRepMedicaid5b) * 100;

            return Json(new { uper = FiveRepMedicaid5b }, JsonRequestBehavior.AllowGet);
        }



        //end of 5th report
        //New function for 3rd Report
        public SqlDataReader fetch3rdReport()
        {

            string query = "select [FirstCol],[SecondCol],[ThirdCol],[FourCol],[FiveCol],[SixCol],[SevenCol],[EightCol],[NineCol],[TenCol],[ElevenCol],[TwelveCol] from Drugs_Reports where ReportType= 'Total'";
            var command = new SqlCommand(query, connectionString);
            SqlDataReader ThirdReport = command.ExecuteReader();
            //F = FiveRep1f;
            return ThirdReport;
        }
        //New function for 4rd Report
        public SqlDataReader fetch4thReport()
        {

            string query = "select [FirstCol],[SecondCol],[ThirdCol],[FourCol],[FiveCol],[SixCol],[SevenCol],[EightCol],[NineCol],[TenCol],[ElevenCol],[TwelveCol] from Drugs_Reports where ReportType= 'HIV'";
            var command = new SqlCommand(query, connectionString);
            SqlDataReader ThirdReport = command.ExecuteReader();
            //F = FiveRep1f;
            return ThirdReport;
        }
        //New function for 5th Report
        public SqlDataReader fetch5thReport()
        {

            string query = "select [FirstCol],[SecondCol],[ThirdCol],[FourCol],[FiveCol],[SixCol],[SevenCol],[EightCol],[NineCol],[TenCol],[ElevenCol],[TwelveCol] from Drugs_Reports where ReportType= 'DIB'";
            var command = new SqlCommand(query, connectionString);
            SqlDataReader ThirdReport = command.ExecuteReader();
            //F = FiveRep1f;
            return ThirdReport;
        }
        //report-7 Pharmacy Diagnosis Code Report
        public IEnumerable<Dictionary<string, object>> Serialize(SqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }
        private Dictionary<string, object> SerializeRow(IEnumerable<string> cols,
                                                SqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }
        public object PDCR_Detail()
        {

            string query = "select * FROM PharmacyDiagnosisCodeReport";
            var command = new SqlCommand(query, connectionString);
            SqlDataReader SEVENTHREPORT_DETAILS = command.ExecuteReader();
            var result = Serialize(SEVENTHREPORT_DETAILS);
            SEVENTHREPORT_DETAILS.Close();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            json = json.Replace("\r\n", string.Empty);
            return json;
        }
        public object PDCR_sum()
        {

            string query = "SELECT [ICD10CodeDec], count(*)  as patient FROM PharmacyDiagnosisCodeReport group by [ICD10CodeDec] order by count(*) desc";
            var command = new SqlCommand(query, connectionString);
            SqlDataReader SEVENTHREPORT_Sum = command.ExecuteReader();
            var result2 = Serialize(SEVENTHREPORT_Sum);
            SEVENTHREPORT_Sum.Close();
            string json = JsonConvert.SerializeObject(result2, Formatting.Indented);
            json = json.Replace("\r\n", string.Empty);
            return json;
        }

        public object ORM_Details()
        {

            string query = "Select * from UniqueMatch";
            var command = new SqlCommand(query, connectionString);
            SqlDataReader SEVENTHREPORT_Sum = command.ExecuteReader();
            var result2 = Serialize(SEVENTHREPORT_Sum);
            SEVENTHREPORT_Sum.Close();
            string json = JsonConvert.SerializeObject(result2, Formatting.Indented);
            json = json.Replace("\r\n", string.Empty);
            return json;
        }

        public object ORM_sum()
        {

            string query = "select Category ,sum(RXCount) as RXCount, sum(OppourtunityofRevenue) as OpportunityRev from UniqueMatch where Category is not NULL group by Category";
            var command = new SqlCommand(query, connectionString);
            SqlDataReader SEVENTHREPORT_Sum = command.ExecuteReader();
            var result2 = Serialize(SEVENTHREPORT_Sum);
            SEVENTHREPORT_Sum.Close();
            string json = JsonConvert.SerializeObject(result2, Formatting.Indented);
            json = json.Replace("\r\n", string.Empty);
            return json;
        }

    }
}