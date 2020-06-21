using Microsoft.Ajax.Utilities;
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
        float SecRep2a2 = 0, SecRep2a4 = 0, SecRep2a6 = 0, SecRep2a8 = 0, SecRep2a10 = 0;
        int ThirdRep1a, ThirdRep1b, ThirdRep1c, ThirdRep1f, ThirdRep1g, ThirdRep1h;
        float ThirdRep1d, ThirdRep1e, ThirdRep1i, ThirdRep1j;
        int ThirdRepMedicaid3a;
        float ThirdRepMedicaid3b;
        int FourRep1a, FourRep1b, FourRep1c, FourRep1f, FourRep1g, FourRep1h;
        float FourRep1d, FourRep1e, FourRep1i, FourRep1j;
        int FourRepMedicaid4a;
        float FourRepMedicaid4b;

        int FiveRep1a, FiveRep1b, FiveRep1c, FiveRep1f, FiveRep1g, FiveRep1h;
        float FiveRep1d, FiveRep1e, FiveRep1i, FiveRep1j;
        int FiveRepMedicaid5a;
        float FiveRepMedicaid5b;


        float h, i, n, m, p, percent_UPERNCP, uper_float, upercp_float, result_UPER_float, percent_UPER = 0, SecRep1_float = 0, SecRep3_float = 0, SecRep4_float = 0;
        SqlConnection connectionString = new SqlConnection(@"Data Source=talhaserver.database.windows.net;Initial Catalog=spectrum;Persist Security Info=True;User ID=demo;Password=Admin@123");
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

                return Json(new { ESrx = new[] { new { ERxs1 = a, ERxs2 = b, ERxs3 = c, ERxs4 = d } }, Total = new[] { new { Total1 = e, Total2 = f, Total3 = g, Total4 = h + "%", Total5 = i + "%" } }, PatientProfile = new[] { new { pp1 = UPER, pp2 = UPERCP, pp3 = result_UPER_float, pp4 = percent_UPER + "%", pp5 = percent_UPERNCP + "%" } } }, JsonRequestBehavior.AllowGet);
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

                return Json(new { EP = new[] { new { EP1 = SecRep, EP2 = SecRep1, EP3 = SecRep2, EP4 = Math.Round(SecRep3_float, 2) + "%", EP5 = Math.Round(SecRep4_float, 2) + "%" } }, EIC = new[] { new { EIC1 = SecRep, EIC2 = SecRep2a1, EIC3 = Math.Round(SecRep2a2, 2) + "%", EIC4 = SecRep2a3, EIC5 = Math.Round(SecRep2a4, 2) + "%", EIC6 = SecRep2a5, EIC7 = Math.Round(SecRep2a6, 2) + "%", EIC8 = SecRep2a7, EIC9 = Math.Round(SecRep2a8, 2) + "%", EIC10 = SecRep2a9, EIC11 = Math.Round(SecRep2a10, 2) + "%" } }, MCO = new[] { new { MCO1 = j, MCO2 = k, MCO3 = l, MCO4 = m + "%", MCO5 = n + "%", MCO6 = o, MCO7 = p + "%" } } });
            }
            else if (opts.Equals("3"))
            {
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

                connectionString.Close();

                return Json(new { TTD = new[] { new { TTD1 = ThirdRep1a, TTD2 = ThirdRep1b, TTD3 = ThirdRep1c, TTD4 = Math.Round(ThirdRep1d, 2) + "%", TTD5 = Math.Round(ThirdRep1e, 2) + "%", TTD6 = ThirdRep1f, TTD7 = ThirdRep1g, TTD8 = ThirdRep1h, TTD9 = Math.Round(ThirdRep1i, 2) + "%", TTD10 = Math.Round(ThirdRep1j, 2) + "%" } }, TDMC = new[] { new { TDMC1 = ThirdRepMedicaid3a, TDMC2 = Math.Round(ThirdRepMedicaid3b, 2) + "%" } } });

            }
            else if (opts.Equals("4"))
            {
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

                connectionString.Close();

                return Json(new { HIV = new[] { new { HIV1 = FourRep1a, HIV2 = FourRep1b, HIV3 = FourRep1c, HIV4 = Math.Round(FourRep1d, 2) + "%", HIV5 = Math.Round(FourRep1e, 2) + "%", HIV6 = FourRep1f, HIV7 = FourRep1g, HIV8 = FourRep1h, HIV9 = Math.Round(FourRep1i, 2) + "%", HIV10 = Math.Round(FourRep1j, 2) + "%" } }, HDMC = new[] { new { HDMC1 = FourRepMedicaid4a, HDMC2 = Math.Round(FourRepMedicaid4b, 2) + "%" } } });

            }
            else if (opts.Equals("5"))
            {
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

                connectionString.Close();

                return Json(new { DDR = new[] { new { DDR1 = FiveRep1a, DDR2 = FiveRep1b, DDR3 = FiveRep1c, DDR4 = Math.Round(FiveRep1d, 2) + "%", DDR5 = Math.Round(FiveRep1e, 2) + "%", DDR6 = FiveRep1f, DDR7 = FiveRep1g, DDR8 = FiveRep1h, DDR9 = Math.Round(FiveRep1i, 2) + "%", DDR10 = Math.Round(FiveRep1j, 2) + "%" } }, TDMCDDR = new[] { new { TDMC1 = FiveRepMedicaid5b, TDMC2 = Math.Round(FiveRepMedicaid5b, 2) + "%" } } });

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
            float perNonContracted = ((float)B / (float)A) * 100;
            h = (float)Math.Round(perNonContracted, 2);

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
            float perContracted = ((float)C / (float)A) * 100;
            i = (float)Math.Round(perContracted, 2);
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
            float perMCOContracted = ((float)E / (float)D) * 100;
            m = (float)Math.Round(perMCOContracted, 2);
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
            float perMCO_nonContracted = ((float)F / (float)D) * 100;
            n = (float)Math.Round(perMCO_nonContracted, 2);
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
            float perMCO_excWalgreen = ((float)G / (float)D) * 100;
            p = (float)Math.Round(perMCO_excWalgreen, 2);
            return Json(new { perMCO_Walgreen = perMCO_excWalgreen }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public object UniquePatients_EscriptRec()
        {

            string query = "select Count(Distinct patientid) from SpectrumEscriptData";
            var command = new SqlCommand(query, connectionString);
            UPER = (int)command.ExecuteScalar();
            uper_float = (float)UPER;

            return Json(new { uper = UPER }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public object UniquePatients_EscriptRecConPharma()
        {

            string query = "select Count(Distinct patientid) from SpectrumEscriptData, ContractPharmaciesFillingExs where pharmacy = ActiveContractedPharmacies and filling like '%y%'";
            var command = new SqlCommand(query, connectionString);
            UPERCP = (int)command.ExecuteScalar();
            upercp_float = (float)UPERCP;

            return Json(new { uper = UPERCP }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public object UniquePatients_EscriptRecNonConPharma()
        {   //A-B
            result_UPER = UPER - UPERCP;
            result_UPER_float = (float)result_UPER;
            return Json(new { uper_result = result_UPER }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object Perc_UniquePatients_EscriptRecCon()
        {   //(B/A)*100
            float res_uper = (upercp_float / uper_float) * 100;
            percent_UPER = (float)Math.Round(res_uper, 2);
            return Json(new { uper_percentage = percent_UPER }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object Perc_UniquePatients_EscriptNonRecCon()
        {   //(C/A)*100
            float res_uoer = (result_UPER_float / uper_float) * 100;
            percent_UPERNCP = (float)Math.Round(res_uoer, 2);
            return Json(new { uper_percentage = percent_UPERNCP }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public object totalEscriptInsuranceCovered()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Cash'";
            var command = new SqlCommand(query, connectionString);
            SecRep1 = (int)command.ExecuteScalar();
            SecRep1_float = (float)SecRep1;

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
            SecRep3_float = ((float)SecRep1 / (float)A) * 100;
            return Json(new { uper = SecRep3_float }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object totalEscriptInsuranceCashCoveredPer()
        {
            SecRep4_float = (float)100.00 - SecRep3_float;
            return Json(new { uper = SecRep4_float }, JsonRequestBehavior.AllowGet);
        }

        public object totalERxSecReport2Mediacaid()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Medicaid'";
            var command = new SqlCommand(query, connectionString);
            SecRep2a1 = (int)command.ExecuteScalar();
            //SecRep2a1_float = (float)SecRep2a1;

            return Json(new { uper = SecRep2a1 }, JsonRequestBehavior.AllowGet);
        }

        public object totalERxSecReport2Commercial()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Commercial'";
            var command = new SqlCommand(query, connectionString);
            SecRep2a3 = (int)command.ExecuteScalar();
            //SecRep2a3_float = (float)SecRep2a3;

            return Json(new { uper = SecRep2a3 }, JsonRequestBehavior.AllowGet);
        }

        public object totalERxSecReport2Medicare()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Medicare'";
            var command = new SqlCommand(query, connectionString);
            SecRep2a5 = (int)command.ExecuteScalar();
            //SecRep2a5_float = (float)SecRep2a5;

            return Json(new { uper = SecRep2a5 }, JsonRequestBehavior.AllowGet);
        }

        public object totalERxSecReport2Tricare()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Tricare'";
            var command = new SqlCommand(query, connectionString);
            SecRep2a7 = (int)command.ExecuteScalar();
            //SecRep2a7_float = (float)SecRep2a7;

            return Json(new { uper = SecRep2a7 }, JsonRequestBehavior.AllowGet);
        }

        public object totalERxSecReport2Cash()
        {

            string query = "select count(distinct [order id]) from SpectrumEscriptData, PayerType where [insurance name] = [Payer Name] and [Payer Type] = 'Cash'";
            var command = new SqlCommand(query, connectionString);
            SecRep2a9 = (int)command.ExecuteScalar();
            //SecRep2a9_float = (float)SecRep2a9;

            return Json(new { uper = SecRep2a9 }, JsonRequestBehavior.AllowGet);
        }
        public object totalERxSecReport2MediacaidPer()
        {
            SecRep2a2 = ((float)SecRep2a1 / (float)A) * 100;
            return Json(new { uper = SecRep2a2 }, JsonRequestBehavior.AllowGet);
        }
        public object totalERxSecReport2CommercialPer()
        {
            SecRep2a4 = ((float)SecRep2a3 / (float)A) * 100;
            return Json(new { uper = SecRep2a4 }, JsonRequestBehavior.AllowGet);

        }
        public object totalERxSecReport2MedicarePer()
        {
            SecRep2a6 = ((float)SecRep2a5 / (float)A) * 100;
            return Json(new { uper = SecRep2a6 }, JsonRequestBehavior.AllowGet);

        }
        public object totalERxSecReport2TricarePer()
        {
            SecRep2a8 = ((float)SecRep2a7 / (float)A) * 100;
            return Json(new { uper = SecRep2a8 }, JsonRequestBehavior.AllowGet);

        }
        public object totalERxSecReport2CashPer()
        {
            SecRep2a10 = ((float)SecRep2a9 / (float)A) * 100;
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
            //SecRep2a9_float = (float)SecRep2a9;
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
            ThirdRep1d = ((float)B / (float)A) * 100;
            return Json(new { uper = ThirdRep1d }, JsonRequestBehavior.AllowGet);
        }

        public object TotalTargetDrugsReport3e()
        {
            ThirdRep1e = ((float)C / (float)A) * 100;
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
            ThirdRep1i = ((float)G / (float)F) * 100;
            return Json(new { uper = ThirdRep1i }, JsonRequestBehavior.AllowGet);
        }

        public object TotalTargetDrugsReport3j()
        {
            ThirdRep1j = ((float)H / (float)F) * 100;
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
            ThirdRepMedicaid3b = ((float)A / (float)ThirdRepMedicaid3b) / 100;

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
            //SecRep2a9_float = (float)SecRep2a9;
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
            FourRep1d = ((float)B / (float)A) * 100;
            return Json(new { uper = FourRep1d }, JsonRequestBehavior.AllowGet);
        }

        public object HivTargetDrugsReport3e()
        {
            FourRep1e = ((float)C / (float)A) * 100;
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
            FourRep1i = ((float)G / (float)F) * 100;
            return Json(new { uper = FourRep1i }, JsonRequestBehavior.AllowGet);
        }

        public object HivTargetDrugsReport3j()
        {
            FourRep1j = ((float)H / (float)F) * 100;
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
            FourRepMedicaid4b = ((float)A / (float)FourRepMedicaid4b) * 100;

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
            //SecRep2a9_float = (float)SecRep2a9;
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
            FiveRep1d = ((float)B / (float)A) * 100;
            return Json(new { uper = FiveRep1d }, JsonRequestBehavior.AllowGet);
        }

        public object DibTargetDrugsReport3e()
        {
            FiveRep1e = ((float)C / (float)A) * 100;
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
            FiveRep1i = ((float)G / (float)F) * 100;
            return Json(new { uper = FiveRep1i }, JsonRequestBehavior.AllowGet);
        }

        public object DibTargetDrugsReport3j()
        {
            FiveRep1j = ((float)H / (float)F) * 100;
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
            FiveRepMedicaid5b = ((float)A / (float)FiveRepMedicaid5b) * 100;

            return Json(new { uper = FiveRepMedicaid5b }, JsonRequestBehavior.AllowGet);
        }



        //end of 5th report


    }
}