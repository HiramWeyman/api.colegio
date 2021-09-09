using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using api.colegio.Models;
namespace api.colegio.Controllers
{
    public class PruebaController : ApiController
    {
        public Paragraph Titulo(string text) {
            Paragraph titulo = new Paragraph();
            ParagraphProperties TituloProperties = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "Normal" };
            Bold boldTitle = new Bold();
            Justification Titulojustification = new Justification() { Val = JustificationValues.Center };
            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            TituloProperties.Append(paragraphStyleId1);
            TituloProperties.Append(boldTitle);
            TituloProperties.Append(Titulojustification);
            TituloProperties.Append(paragraphMarkRunProperties1);
            Run run = new Run();
            RunProperties runPropertiesTitulo = new RunProperties(new RunFonts()
            {
                Ascii = "Arial"
            },
            new FontSize()
            {
                Val = "50"
            });

            Text textTitulo = new Text() { Text = text };

            // siga a ordem 
            run.Append(runPropertiesTitulo);
            run.Append(textTitulo);
            titulo.Append(TituloProperties);
            titulo.Append(run);

            return titulo;

        }
        public Paragraph Subtitulo(string text) {

            Paragraph subtitulo = new Paragraph();
            ParagraphProperties subtituloProperties = new ParagraphProperties();
            ParagraphStyleId paragraphStyleIdsub = new ParagraphStyleId() { Val = "Normal" };
            Bold boldsubTitle = new Bold();
            Justification subtitulojustification = new Justification() { Val = JustificationValues.Left };
            ParagraphMarkRunProperties subparagraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            subtituloProperties.Append(paragraphStyleIdsub);
            subtituloProperties.Append(boldsubTitle);
            subtituloProperties.Append(subtitulojustification);
            subtituloProperties.Append(subparagraphMarkRunProperties1);
            Run runSubtitulo = new Run();
            RunProperties runPropertiessubTitulo = new RunProperties(new RunFonts()
            {
                Ascii = "Arial"
            },
            new FontSize()
            {
                Val = "30"
            });

            Text textSubTitulo = new Text() { Text = text };

            // siga a ordem 
            runSubtitulo.Append(runPropertiessubTitulo);
            runSubtitulo.Append(textSubTitulo);
            subtitulo.Append(subtituloProperties);
            subtitulo.Append(runSubtitulo);

            return subtitulo;
        }

        public Paragraph SubtituloSeccion(string text)
        {

            Paragraph subtitulo = new Paragraph();
            ParagraphProperties subtituloProperties = new ParagraphProperties();
            ParagraphStyleId paragraphStyleIdsub = new ParagraphStyleId() { Val = "Normal" };
            Bold boldsubTitle = new Bold();
            Justification subtitulojustification = new Justification() { Val = JustificationValues.Center };
            ParagraphMarkRunProperties subparagraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            subtituloProperties.Append(paragraphStyleIdsub);
            subtituloProperties.Append(boldsubTitle);
            subtituloProperties.Append(subtitulojustification);
            subtituloProperties.Append(subparagraphMarkRunProperties1);
            Run runSubtitulo = new Run();
            RunProperties runPropertiessubTitulo = new RunProperties(new RunFonts()
            {
                Ascii = "Arial"
            },
            new FontSize()
            {
                Val = "30"
            });

            Text textSubTitulo = new Text() { Text = text };

            // siga a ordem 
            runSubtitulo.Append(runPropertiessubTitulo);
            runSubtitulo.Append(textSubTitulo);
            subtitulo.Append(subtituloProperties);
            subtitulo.Append(runSubtitulo);

            return subtitulo;
        }

        public Paragraph TituloPregunta(string text)
        {
            Paragraph titulo = new Paragraph();
            ParagraphProperties TituloProperties = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "Normal" };
            Bold boldTitle = new Bold();
            Justification Titulojustification = new Justification() { Val = JustificationValues.Center };
            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            TituloProperties.Append(paragraphStyleId1);
            TituloProperties.Append(boldTitle);
            TituloProperties.Append(Titulojustification);
            TituloProperties.Append(paragraphMarkRunProperties1);
            Run run = new Run();
            RunProperties runPropertiesTitulo = new RunProperties(new RunFonts()
            {
                Ascii = "Arial"
            },
            new FontSize()
            {
                Val = "35"
            });

            Text textTitulo = new Text() { Text = text };

            // siga a ordem 
            run.Append(runPropertiesTitulo);
            run.Append(textTitulo);
            titulo.Append(TituloProperties);
            titulo.Append(run);

            return titulo;

        }

        public Paragraph TituloParrafo(string text)
        {

            Paragraph parrafo = new Paragraph();
            ParagraphProperties ParrafoProperties = new ParagraphProperties();
            ParagraphStyleId ParrafoParagraphStyleId = new ParagraphStyleId() { Val = "Normal" };
            Bold boldParrafo = new Bold();
            Justification ParrafoJustification = new Justification() { Val = JustificationValues.Left };
            ParagraphMarkRunProperties ParrafoParagraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            ParrafoProperties.Append(ParrafoParagraphStyleId);
            ParrafoProperties.Append(boldParrafo);
            ParrafoProperties.Append(ParrafoJustification);
            ParrafoProperties.Append(ParrafoParagraphMarkRunProperties1);
            Run runParrafo = new Run();
            RunProperties runPropertiessubTitulo = new RunProperties(new RunFonts()
            {
                Ascii = "Arial"
            },
                new FontSize()
                {
                    Val = "25"
                });

            Text textSubTitulo = new Text() { Text = text };

            // siga a ordem 
            runParrafo.Append(runPropertiessubTitulo);
            runParrafo.Append(textSubTitulo);
            parrafo.Append(ParrafoProperties);
            parrafo.Append(runParrafo);

            return parrafo;
        }

        public Paragraph Parrafo(string text)
        {

            Paragraph parrafo = new Paragraph();
            ParagraphProperties ParrafoProperties = new ParagraphProperties();
            ParagraphStyleId ParrafoParagraphStyleId= new ParagraphStyleId() { Val = "Normal" };
            //Bold boldParrafo = new Bold();
            Justification ParrafoJustification = new Justification() { Val = JustificationValues.Left };
            ParagraphMarkRunProperties ParrafoParagraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            ParrafoProperties.Append(ParrafoParagraphStyleId);
            //ParrafoProperties.Append(boldParrafo);
            ParrafoProperties.Append(ParrafoJustification);
            ParrafoProperties.Append(ParrafoParagraphMarkRunProperties1);
            Run runParrafo = new Run();
            RunProperties runPropertiessubTitulo = new RunProperties(new RunFonts()
            {
                Ascii = "Arial"
            });

            Text textSubTitulo = new Text() { Text = text };

            // siga a ordem 
            runParrafo.Append(runPropertiessubTitulo);
            runParrafo.Append(textSubTitulo);
            parrafo.Append(ParrafoProperties);
            parrafo.Append(runParrafo);

            return parrafo;
        }

        public Paragraph DescPaciente(string aspectos,string vestimenta, string porte, string movimientos,string afecto) {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";


            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Aspectos Generales."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(aspectos));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Vestimenta y aliño."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(vestimenta));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("3.Porte y actitud."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(porte));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("4.Movimientos, voz y lenguaje."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(movimientos));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("5.Afecto."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(afecto));
            run2.AppendChild(new Break());

            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph MotivoConsulta(string problema,string historia,string referencia,string experiencia)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";


            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Problema actual."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(problema));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Historia del problema."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(historia));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("3.Referencia."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(referencia));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("4.Experiencia y Tx."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(experiencia));
            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph Situacion(string dia, string ocaciones)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";

      
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Día común y corriente."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(dia));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Ocaciones especiales."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(ocaciones));
            run2.AppendChild(new Break());
            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph Constelacion(string observaciones,string antecedentes,string descripcion,string hermanos,string rivalidades,string papel,string uniones,string normas,string cambios)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";


            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Observación."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(observaciones));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Antecedentes patológicos."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(antecedentes));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Descripción del padre y la madre."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(descripcion));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("3.Hermanos."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(hermanos));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("4.Rivalidades."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(rivalidades));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("5.Papel dentro de la familia."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(papel));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("6.Uniones y fricciones."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(uniones));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("7.Normas sociales."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(normas));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("8.Cambios en la constelación familiar."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(cambios));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph RecuerdosTemp(string recuerdos)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";

   
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Recuerdos tempranos."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(recuerdos));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
 
            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph HistoriaPer(string embarazo, string inicio, string infancia, string ninez, string adolecencia, string adulta, string avanzada, string alimentacion, string sueno, string enfermedades, string lesiones, string opinion)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";

            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Embarazo y nacimiento."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(embarazo));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Inició marcha, habla y control de esfinteres."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(inicio));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("3.Infancia; hábitos, alimentación, etc."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(infancia));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("4.Niñez; relaciones sociales, temores, etc."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(ninez));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("5.Adolecencia; problemas, relaciones interpersonales."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(adolecencia));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("6.Edad adulta; logros, satisfacciones, etc."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(adulta));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("7.Edad avanzada; abandono de los hijos, temor a la muerte."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(avanzada));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("8.Alimentación."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(alimentacion));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("9.Sueño."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(sueno));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("10.Enfermedades."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(enfermedades));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("11.Lesiones,operaciones."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(lesiones));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("12.Opinión de salud actual."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(opinion));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph Escolaridad(string primaria, string secundaria, string preparatoria, string universidad, string otras, string relacion, string rendimiento, string cambios, string evaluacion)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";


            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Escuelas a las que asistió."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Primaria:"));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(primaria));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Secundaria:"));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(secundaria));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Preparatoria:"));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(preparatoria));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Universidad:"));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(universidad));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Otras:"));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(otras));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Relación con los maestros y compañeros."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(relacion));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Rendimiento escolar."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(rendimiento));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("3.Cambios de escuela."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(cambios));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("4.Evaluacion personal de vida escolar."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(evaluacion));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
    
            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph Diversion(string lectura, string practicas, string pertenencia)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";


            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Lectura, música, deportes, etc."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(lectura));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Prácticas religiosas."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(practicas));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("3.Pertenencia a grupo."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(pertenencia));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());

            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph Ajustes(string rel, string amistad, string sentir,string novia)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";


            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Relaciones interpersonales."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(rel));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Amistades (Hombres-Mujeres)."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(amistad));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("3.Su sentir respecto a sus amistades."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(sentir));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("4.Novios(as)(Cuantos y como fue la relación)."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(novia));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());

            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph DesarrolloSex(string nociones,string contacto,string interes,string mast,string homo,string relpre)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";

      
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Primeras nociones acerca del sexo."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(nociones));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Primer contacto sexual."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(contacto));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("3.Evolución e interes sexual."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(interes));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("4.Masturbación, sueños y fantasías sexuales."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(mast));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("5.Homosexualidad."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(homo));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("6.Relaciones premaritales, maritales y extramarital."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(relpre));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());

            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph DatosMaritales(string noviazgo, string expectativas, string descon, string eventos, string hijos, string interaccion, string familia)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";

      
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Noviazgo."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(noviazgo));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Expectativas de noviazgo."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(expectativas));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("3.Descripción del cónyuge."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(descon));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("4.Eventos importantes."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(eventos));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("5.Número de hijos, preferencias."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(hijos));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("6.Interacción de la familia actual."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(interaccion));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("7.Cómo se siente respecto a su familia."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(familia));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());

            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph DescSimismo(string afuera, string demas, string preocupaciones, string metas, string sido, string crisis, string triunfo, string problemas)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";

    
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Como se ve desde afuera."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(afuera));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Como cree que lo ven los demás."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(demas));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("3.Preocupaciones, dudas, etc."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(preocupaciones));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("4.Metas."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(metas));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("5.Como le gustaria haber sido."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(sido));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("6.Las crisis más importantes."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(crisis));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("7.Descripción de un triunfo y un fracaso."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(triunfo));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("8.Cómo se siente ante sus problemas."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(problemas));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());

            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }
        public Paragraph EstadoMental(string estado, string orientacion, string afectividad, string asociaciones, string contenido, string percepcion, string funcionamiento , string juicio,string insight,string madurez)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";

       
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("1.Estado de conciencia."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(estado));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("2.Orientación, tiempo, espacio."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(orientacion));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("3.Afectividad y estado de ánimo."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(afectividad));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("4.Asociaciones y pensamiento."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(asociaciones));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("5.Contenido del pensamiento."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(contenido));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("6.Percepción."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(percepcion));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("7.Funcionamiento Sintético-Integrativo."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(funcionamiento));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("8.Juicio."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(juicio));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("9.Insight."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(insight));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("10.Madurez."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(madurez));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());

            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph Diagnostico(string cognitivo, string psicometrico, string diagnostico_, string primario, string especifico, string pronostico)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";

 
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Perfil cognitivo."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(cognitivo));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Pruebas psicométricas."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(psicometrico));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Diagnóstico."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(diagnostico_));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Diagnóstico primario."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(primario));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Diagnóstico específico."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(especifico));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Pronóstico."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(pronostico));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }

        public Paragraph Psicoterapia(string desc, string texto, string objetivo, string tecnicas, string res, string recomendaciones, string observaciones)
        {


            Paragraph para2 = new Paragraph();
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
            Justification justification2 = new Justification() { Val = JustificationValues.Start };
            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();
            RunProperties runProperties3 = new RunProperties();
            //Text text2 = new Text();
            //text2.Text = "Teste aqui";


            run2.AppendChild(new Break());
            run2.AppendChild(new Text(desc));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Diagnóstico o Descrición del problema."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(texto));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Objetivo de intervención."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(objetivo));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Técnicas o procedimiento de intervención."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(tecnicas));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Resultados."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(res));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Recomendaciones."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(recomendaciones));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Text("Observaciones."));
            run2.AppendChild(new Break());
            run2.AppendChild(new Text(observaciones));
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());
            run2.AppendChild(new Break());

            para2.Append(paragraphProperties2);
            para2.Append(run2);

            return para2;
        }
        public Table Tabla(
            string nombre,
            string direccion,
            string ocupacion,
            string fnac,
            string fing,
            string genero,
            string edad,
            string edocivil,
            string telefono,
            string telefono_eme,
            string escolaridad,
            string edo,
            string mun,
            string edo_res,
            string mun_res,
            string mod,
            string estatus
            ) {
            //// Create a new table

            Table tbl = new Table();

            // Set the style and width for the table.
            TableProperties tableProp = new TableProperties();
            TableStyle tableStyle = new TableStyle() { Val = "TableGrid" };


            // Add 3 columns to the table.
            TableGrid tg = new TableGrid(new GridColumn(), new GridColumn());
            tbl.AppendChild(tg);

            // Create 1 row to the table.
            TableRow tr1 = new TableRow();
            TableRow tr2 = new TableRow();
            TableRow tr3 = new TableRow();
            TableRow tr4 = new TableRow();
            TableRow tr5 = new TableRow();
            TableRow tr6 = new TableRow();
            TableRow tr7 = new TableRow();
            TableRow tr8 = new TableRow();
            TableRow tr9 = new TableRow();
            TableRow tr10 = new TableRow();
            TableRow tr11= new TableRow();
            TableRow tr12 = new TableRow();
            TableRow tr13 = new TableRow();
            TableRow tr14 = new TableRow();
            TableRow tr15 = new TableRow();
            TableRow tr16 = new TableRow();
            TableRow tr17 = new TableRow();

            // Add a cell to each column in the row.
            TableCell tc1 = new TableCell();
            tc1.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tc2 = new TableCell();
            tc2.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tc1.Append(new Paragraph(new Run(new Text("NOMBRE:"))));
            tc2.Append(new Paragraph(new Run(new Text(nombre))));

            TableCell tcDir = new TableCell();
            tcDir.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcDirtext = new TableCell();
            tcDirtext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "8000" }));

            // Specify the table cell content.
            tcDir.Append(new Paragraph(new Run(new Text("DIRECCIÓN:"))));
            tcDirtext.Append(new Paragraph(new Run(new Text(direccion))));

            TableCell tcOcup = new TableCell();
            tcOcup.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcOcuptext = new TableCell();
            tcOcuptext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcOcup.Append(new Paragraph(new Run(new Text("OCUPACIÓN:"))));
            tcOcuptext.Append(new Paragraph(new Run(new Text(ocupacion))));

            TableCell tcGen = new TableCell();
            tcGen.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcGentext = new TableCell();
            tcGentext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcGen.Append(new Paragraph(new Run(new Text("GÉNERO:"))));
            tcGentext.Append(new Paragraph(new Run(new Text(genero))));


            TableCell tcFnac = new TableCell();
            tcFnac.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcFnactext = new TableCell();
            tcFnactext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcFnac.Append(new Paragraph(new Run(new Text("F_NACIMIENTO:"))));
            tcFnactext.Append(new Paragraph(new Run(new Text(fnac))));

            TableCell tcFing = new TableCell();
            tcFing.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcFingtext = new TableCell();
            tcFingtext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcFing.Append(new Paragraph(new Run(new Text("F_INGRESO:"))));
            tcFingtext.Append(new Paragraph(new Run(new Text(fing))));

            TableCell tcEdad = new TableCell();
            tcEdad.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcEdadtext = new TableCell();
            tcEdadtext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcEdad.Append(new Paragraph(new Run(new Text("EDAD:"))));
            tcEdadtext.Append(new Paragraph(new Run(new Text(edad))));

            TableCell tcEdocivil = new TableCell();
            tcEdocivil.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcEdociviltext = new TableCell();
            tcEdociviltext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcEdocivil.Append(new Paragraph(new Run(new Text("ESTADO CIVIL:"))));
            tcEdociviltext.Append(new Paragraph(new Run(new Text(edocivil))));

            TableCell tcTelefono = new TableCell();
            tcTelefono.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcTelefonotext = new TableCell();
            tcTelefonotext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcTelefono.Append(new Paragraph(new Run(new Text("TELEFONO:"))));
            tcTelefonotext.Append(new Paragraph(new Run(new Text(telefono))));


            TableCell tcTelefono_eme = new TableCell();
            tcTelefono_eme.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcTelefono_emetext = new TableCell();
            tcTelefono_emetext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcTelefono_eme.Append(new Paragraph(new Run(new Text("TELEFONO DE EMERGERCIA:"))));
            tcTelefono_emetext.Append(new Paragraph(new Run(new Text(telefono_eme))));

            TableCell tcEscolaridad = new TableCell();
            tcEscolaridad.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcEscolaridadtext = new TableCell();
            tcEscolaridadtext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcEscolaridad.Append(new Paragraph(new Run(new Text("ESCOLARIDAD:"))));
            tcEscolaridadtext.Append(new Paragraph(new Run(new Text(escolaridad))));

            TableCell tcEstado = new TableCell();
            tcEstado.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcEstadotext = new TableCell();
            tcEstadotext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcEstado.Append(new Paragraph(new Run(new Text("ESTADO:"))));
            tcEstadotext.Append(new Paragraph(new Run(new Text(edo))));

            TableCell tcMunicipio = new TableCell();
            tcMunicipio.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcMunicipiotext = new TableCell();
            tcMunicipiotext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcMunicipio.Append(new Paragraph(new Run(new Text("MUNICIPIO:"))));
            tcMunicipiotext.Append(new Paragraph(new Run(new Text(mun))));


            //lugar residencia
            TableCell tcEstadores = new TableCell();
            tcEstadores.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcEstadorestext = new TableCell();
            tcEstadorestext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcEstadores.Append(new Paragraph(new Run(new Text("ESTADO DE RESIDENCIA:"))));
            tcEstadorestext.Append(new Paragraph(new Run(new Text(edo_res))));

            TableCell tcMunicipiores = new TableCell();
            tcMunicipiores.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcMunicipiorestext = new TableCell();
            tcMunicipiorestext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcMunicipiores.Append(new Paragraph(new Run(new Text("MUNICIPIO DE RESIDENCIA:"))));
            tcMunicipiorestext.Append(new Paragraph(new Run(new Text(mun_res))));

            TableCell tcModalidad = new TableCell();
            tcModalidad.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcModalidadtext = new TableCell();
            tcModalidadtext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcModalidad.Append(new Paragraph(new Run(new Text("MODALIDAD:"))));
            tcModalidadtext.Append(new Paragraph(new Run(new Text(mod))));

            TableCell tcEstatus = new TableCell();
            tcEstatus.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            TableCell tcEstatustext = new TableCell();
            tcEstatustext.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3000" }));

            // Specify the table cell content.
            tcEstatus.Append(new Paragraph(new Run(new Text("ESTATUS:"))));
            tcEstatustext.Append(new Paragraph(new Run(new Text(estatus))));
            tr1.Append(tc1,tc2);
            tr2.Append(tcDir, tcDirtext);
            tr3.Append(tcOcup, tcOcuptext);
            tr4.Append(tcFnac, tcFnactext);
            tr5.Append(tcFing, tcFingtext);
            tr6.Append(tcGen, tcGentext);
            tr7.Append(tcEdad, tcEdadtext);
            tr8.Append(tcEdocivil, tcEdociviltext);
            tr9.Append(tcTelefono, tcTelefonotext);
            tr10.Append(tcTelefono_eme, tcTelefono_emetext);
            tr11.Append(tcEscolaridad, tcEscolaridadtext);
            tr12.Append(tcEstado, tcEstadotext);
            tr13.Append(tcMunicipio, tcMunicipiotext);
            tr14.Append(tcEstadores, tcEstadorestext);
            tr15.Append(tcMunicipiores,tcMunicipiorestext);
            tr16.Append(tcModalidad, tcModalidadtext);
            tr17.Append(tcEstatus, tcEstatustext);

            //TableRow tr2 = new TableRow();

            //// Add a cell to each column in the row.
            //TableCell tc3 = new TableCell(new Paragraph(new Run(new Text("DIRECCION:"))));
            //TableCell tc4 = new TableCell(new Paragraph(new Run(new Text("RIOLITA #207 FRACC. EL PEDREGAL"))));

            //tr2.Append(tc3, tc4);

            // Add row to the table.
            tbl.AppendChild(tr1);
            tbl.AppendChild(tr2);
            tbl.AppendChild(tr3);
            tbl.AppendChild(tr4);
            tbl.AppendChild(tr5);
            tbl.AppendChild(tr6);
            tbl.AppendChild(tr7);
            tbl.AppendChild(tr8);
            tbl.AppendChild(tr9);
            tbl.AppendChild(tr10);
            tbl.AppendChild(tr11);
            tbl.AppendChild(tr12);
            tbl.AppendChild(tr13);
            tbl.AppendChild(tr14);
            tbl.AppendChild(tr15);
            tbl.AppendChild(tr16);
            tbl.AppendChild(tr17);


            return tbl;
        }


        [Route("api/Reporte/{id}")]
        [HttpGet]
        public HttpResponseMessage GetReporte(int id) {
            // open xml sdk - docx

            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var infogeneral = db.infogeneral.FirstOrDefault(x => x.paciente_id == id);
                //Variables grlesmpaciente
                string nombre = "";
                string direccion = "";
                string ocupacion = "";
                string fnac = "";
                string fing = "";
                string genero = "";
                string edad = "";
                string edocivil = "";
                string telefono = "";
                string telefono_eme = "";
                string escolaridad = "";
                string edo = "";
                string mun = "";
                string edo_res = "";
                string mun_res = "";
                string mod = "";
                string estatus = "";

                //desc paciente
                string aspecto = "";
                string vestimenta = "";
                string porte = "";
                string movimientos = "";
                string afecto = "";

                //Motivo Cons
                string problema = "";
                string historia = "";
                string referencia = "";
                string experiencia = "";

                //Situacion actual
                string dia="";
                string ocaciones="";

                //Constelacion fam
                string observaciones = "";
                string antecedentes = "";
                string descripcion = "";
                string hermanos = "";
                string rivalidades = "";
                string papel = "";
                string uniones = "";
                string normas = "";
                string cambios = "";

                //recuerdos tempranos
                string recuerdo = "";

                //historia personal
                string embarazo = "";
                string inicio = "";
                string infancia = "";
                string ninez = "";
                string adolecencia = "";
                string adulta = "";
                string avanzada = "";
                string alimentacion = "";
                string sueno = "";
                string enfermedades = "";
                string lesiones = "";
                string opinion = "";

                //Escolaridad
                string primaria = "";
                string secundaria = "";
                string preparatoria = "";
                string universidad = "";
                string otra = "";
                string relacion = "";
                string rendimiento = "";
                string cambio = "";
                string evaluacion = "";

                //Diversiones e intereses
                string lectura="";
                string practicas = "";
                string pertenencia = "";

                //Ajustes sociales
                string relacionesint = "";
                string amistades = "";
                string sentir = "";
                string novios = "";

                //Desarrollo sexual
                string nociones = "";
                string contacto = "";
                string interes = "";
                string mast = "";
                string homo = "";
                string relpre = "";

                //Datos Maritales
                string noviazgo = "";
                string expectativas = "";
                string descon = "";
                string eventos = "";
                string hijos = "";
                string interaccion = "";
                string familia = "";

                //Desc si mismo
                string afuera="";
                string demas = "";
                string preocupaciones = "";
                string metas = "";
                string sido = "";
                string crisis = "";
                string triunfo = "";
                string problemas = "";

                //Estado mental
                string estadocon = "";
                string orientacion = "";
                string afectividad = "";
                string asociaciones = "";
                string contenido = "";
                string percepcion = "";
                string funcionamiento = "";
                string juicio = "";
                string insight = "";
                string madurez = "";

                //Diagnostico
                string cognitivo = "";
                string psicometrico = "";
                string diagnostico_ = "";
                string primario = "";
                string primarioConv = "";
                string especifico = "";
                string pronostico = "";

                if (infogeneral!=null) {
                    nombre = infogeneral.paciente_nombre;
                    direccion= infogeneral.paciente_direccion;
                    ocupacion = infogeneral.paciente_ocupacion;
                    fnac = infogeneral.paciente_fec_nac.ToString();
                    fing = infogeneral.paciente_fec_ing.ToString();
                    genero = infogeneral.sexo_descrip;
                    edad = infogeneral.paciente_edad.ToString();
                    edocivil = infogeneral.edocivil_descrip;
                    telefono = infogeneral.paciente_telefono;
                    telefono_eme = infogeneral.paciente_telefono_eme;
                    escolaridad = infogeneral.escolar_descrip;
                    edo = infogeneral.desc_edo;
                    mun = infogeneral.desc_mun;
                    edo_res = infogeneral.estado_res;
                    mun_res = infogeneral.municipio_res;
                    mod = infogeneral.modalidad_descrip;
                    estatus = infogeneral.estatus_descrip;
                }
                //Consultas
                var descPaciente = db.pac_descrip.Where(x => x.pac_paciente_id == id).Count();
                if (descPaciente > 0) {
                    var descPacienteData= db.pac_descrip.FirstOrDefault(x => x.pac_paciente_id == id);
                    aspecto = descPacienteData.pac_desc_aspectos;
                    vestimenta= descPacienteData.pac_desc_vestimenta;
                    porte = descPacienteData.pac_desc_porte;
                    movimientos = descPacienteData.pac_desc_movimientos;
                    afecto = descPacienteData.pac_desc_afecto;
                }
                var motivocons = db.pac_consulta.Where(x => x.pac_cons_pac_id == id).Count();
                if (motivocons > 0)
                {
                    var motivoconsData = db.pac_consulta.FirstOrDefault(x => x.pac_cons_pac_id == id);
                    if (motivoconsData != null) {
                        problema = motivoconsData.pac_cons_problema;
                        historia = motivoconsData.pac_cons_historia;
                        referencia = motivoconsData.pac_cons_referencia;
                        experiencia = motivoconsData.pac_cons_experiencia;
                    }
                   
                }
          
                var situacion = db.pac_situacion_act.Where(x => x.pac_situacion_pac_id == id).Count();
                if (situacion > 0)
                {
                    var situacionData = db.pac_situacion_act.FirstOrDefault(x => x.pac_situacion_pac_id == id);
                    if (situacionData != null) {
                        dia = situacionData.pac_situacion_dia;
                        ocaciones = situacionData.pac_situacion_esp;
                    }
                   
              
                }
                var constelacion = db.pac_constelacion_fam.Where(x => x.pac_conste_paciene_id == id).Count();
                if (constelacion > 0)
                {
                    var constelacionData = db.pac_constelacion_fam.FirstOrDefault(x => x.pac_conste_paciene_id == id);
                    if (constelacionData != null) {
                        observaciones = constelacionData.pac_conste_texto;
                        antecedentes = constelacionData.pac_conste_antecedentes;
                        descripcion = constelacionData.pac_conste_desc_padre_madre;
                        hermanos = constelacionData.pac_conste_hermanos;
                        rivalidades = constelacionData.pac_conste_rivalidades;
                        papel = constelacionData.pac_conste_papel_fam;
                        uniones = constelacionData.pac_conste_uniones;
                        normas = constelacionData.pac_conste_normas;
                        cambios = constelacionData.pac_conste_cambios;
                    }
                  
                }
                var recuerdos = db.pac_recuerdos_tempranos.Where(x => x.pac_recuerdos_pac_id == id).Count();
                if (recuerdos > 0)
                {
                    var recuerdoseData = db.pac_recuerdos_tempranos.FirstOrDefault(x => x.pac_recuerdos_pac_id == id);
                    if (recuerdoseData != null)
                    {
                        recuerdo = recuerdoseData.pac_recuerdos_temp;

                    }

                }
                var historiaPer = db.pac_historia_per.Where(x => x.pac_hist_pac_id == id).Count();
                if (historiaPer > 0)
                {
                    var historiaPereData = db.pac_historia_per.FirstOrDefault(x => x.pac_hist_pac_id == id);
                    if (historiaPereData != null)
                    {
                        embarazo = historiaPereData.pac_hist_embarazo;
                        inicio = historiaPereData.pac_hist_inicio;
                        infancia = historiaPereData.pac_hist_infancia;
                        ninez = historiaPereData.pac_hist_nines_re;
                        adolecencia = historiaPereData.pac_hist_adolecencia;
                        adulta = historiaPereData.pac_hist_edad_ad;
                        avanzada = historiaPereData.pac_hist_edad_av;
                        alimentacion = historiaPereData.pac_hist_alimentacion;
                        sueno = historiaPereData.pac_hist_sueno;
                        enfermedades = historiaPereData.pac_hist_enfermedades;
                        lesiones = historiaPereData.pac_hist_lesiones;
                        opinion = historiaPereData.pac_hist_salud_act;
                    }
                    
                }
                var escolar = db.pac_escolaridad.Where(x => x.pac_escolaridad_pac_id == id).Count();
                if (escolar > 0)
                {
                    var escolarData = db.pac_escolaridad.FirstOrDefault(x => x.pac_escolaridad_pac_id == id);
                    if (escolarData != null)
                    {
                        primaria = escolarData.pac_escolaridad_primaria;
                        secundaria = escolarData.pac_escolaridad_secundaria;
                        preparatoria = escolarData.pac_escolaridad_preparatoria;
                        universidad = escolarData.pac_escolaridad_universidad;
                        otra = escolarData.pac_escolaridad_otras;
                        relacion = escolarData.pac_escolaridad_relacion;
                        rendimiento = escolarData.pac_escolaridad_rendimiento;
                        cambio = escolarData.pac_escolaridad_cambios;
                        evaluacion = escolarData.pac_escolaridad_evaluacion;
                    }
                   
                }
                var diversion = db.pac_diversion_intereses.Where(x => x.pac_diversion_pac_id == id).Count();
                if (diversion > 0)
                {
                    var diversionData = db.pac_diversion_intereses.FirstOrDefault(x => x.pac_diversion_pac_id == id);
                    if (diversionData != null)
                    {
                        lectura = diversionData.pac_diversion_lectura;
                        practicas = diversionData.pac_diversion_practicas;
                        pertenencia = diversionData.pac_diversion_pertenencia;
                    }
                    
                
                }
                var ajustes = db.pac_ajustes_sociales.Where(x => x.pac_ajustes_pac_id == id).Count();
                if (ajustes > 0)
                {
                    var ajustesData = db.pac_ajustes_sociales.FirstOrDefault(x => x.pac_ajustes_pac_id == id);
                    if (ajustesData != null)
                    {
                        relacionesint = ajustesData.pac_ajustes_relacionesint;
                        amistades = ajustesData.pac_ajustes_amistades;
                        sentir = ajustesData.pac_ajustes_sentir;
                        novios = ajustesData.pac_ajustes_novias;
                    }
                   
                }
                var desarrollo = db.pac_desarrollo_sexual.Where(x => x.pac_desarrollo_pac_id == id).Count();
                if (desarrollo > 0)
                {
                    var desarrolloData = db.pac_desarrollo_sexual.FirstOrDefault(x => x.pac_desarrollo_pac_id == id);
                    if (desarrolloData != null)
                    {
                        nociones = desarrolloData.pac_desarrollo_nociones;
                        contacto = desarrolloData.pac_desarrollo_contacto;
                        interes = desarrolloData.pac_desarrollo_fantasias;
                        mast = desarrolloData.pac_desarrollo_fantasias;
                        homo = desarrolloData.pac_desarrollo_homosex;
                        relpre = desarrolloData.pac_desarrollo_relaciones;
                    }
                   

                }
                var datosmar = db.pac_datos_maritales.Where(x => x.pac_maritales_pac_id == id).Count();
                if (datosmar > 0)
                {
                    var datosmarnData = db.pac_datos_maritales.FirstOrDefault(x => x.pac_maritales_pac_id == id);
                    if (datosmarnData != null)
                    {
                        noviazgo = datosmarnData.pac_maritales_noviazgo;
                        expectativas = datosmarnData.pac_maritales_expnoviazgo;
                        descon = datosmarnData.pac_maritales_desc_conyuge;
                        eventos = datosmarnData.pac_maritales_eventos;
                        hijos = datosmarnData.pac_maritales_numhijos;
                        interaccion = datosmarnData.pac_maritales_interaccion;
                        familia = datosmarnData.pac_maritales_familia;
                    }
                  

                }
                var descsimismo = db.pac_desc_simismo.Where(x => x.pac_simismo_pac_id == id).Count();
                if (descsimismo > 0)
                {
                    var descsimismoData = db.pac_desc_simismo.FirstOrDefault(x => x.pac_simismo_pac_id == id);
                    if (descsimismoData != null)
                    {
                        afuera = descsimismoData.pac_simismo_comoseve;
                        demas = descsimismoData.pac_simismo_comocree;
                        preocupaciones = descsimismoData.pac_simismo_preocupaciones;
                        metas = descsimismoData.pac_simismo_metas;
                        sido = descsimismoData.pac_simismo_gustaria;
                        crisis = descsimismoData.pac_simismo_crisis;
                        triunfo = descsimismoData.pac_simismo_triunfo_frac;
                        problemas = descsimismoData.pac_simismo_siente_problem;
                    }
                   

                }
                var estadomen = db.pac_estado_mental.Where(x => x.pac_estado_pac_id == id).Count();
                if (estadomen > 0)
                {
                    var estadomenData = db.pac_estado_mental.FirstOrDefault(x => x.pac_estado_pac_id == id);
                    if (estadomenData != null)
                    {
                        estadocon = estadomenData.pac_estado_conciencia;
                        orientacion = estadomenData.pac_estado_orientacion;
                        afectividad = estadomenData.pac_estadoafectividad;
                        asociaciones = estadomenData.pac_estado_asociaciones;
                        contenido = estadomenData.pac_estado_pensamiento;
                        percepcion = estadomenData.pac_estado_percepcion;
                        funcionamiento = estadomenData.pac_estado_funcionamiento;
                        juicio = estadomenData.pac_estado_juicio;
                        insight = estadomenData.pac_estado_insight;
                        madurez = estadomenData.pac_estado_madurez;
                    }
                   

                }
                var diagnostico = db.infodiagnostico.Where(x => x.pac_diag_pac_id == id).Count();
                if (diagnostico > 0)
                {
                    var diagnosticoData = db.infodiagnostico.FirstOrDefault(x => x.pac_diag_pac_id == id);
                    if (diagnosticoData != null)
                    {
                        cognitivo = diagnosticoData.pac_diag_perfilcog;
                        psicometrico = diagnosticoData.pac_diag_pruebaspsi;
                        diagnostico_ = diagnosticoData.pac_diag_diagnostico;
                        primario = diagnosticoData.diag_descrip.ToLower();
                        primarioConv = UppercaseFirst(primario);
                        especifico = diagnosticoData.pac_diag_especifico;
                        pronostico = diagnosticoData.pac_diag_pronostico;
                    }
                    

                }
                string UppercaseFirst(string s)
                {
                    if (string.IsNullOrEmpty(s))
                    {
                        return string.Empty;
                    }
                    char[] a = s.ToCharArray();
                    a[0] = char.ToUpper(a[0]);
                    return new string(a);
                }

                List<pac_psicoterapia> sessiones = null;
                sessiones = db.pac_psicoterapia.Where(x => x.pac_psico_pac_id == id).OrderBy(x => x.pac_psico_desc).ToList();
                byte[] buffer;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
                using (MemoryStream stream = new MemoryStream())
                {
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(stream, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
                    {
                        wordDoc.AddMainDocumentPart();
                        // siga a ordem
                        Document doc = new Document();

                        Body body = new Body();


                        // todos os 2 paragrafos no main body
                        body.Append(Titulo("EXPEDIENTE CLÍNICO"));
                        body.Append(new Break());
                        body.Append(Subtitulo("DATOS DEL PACIENTE:"));
                        body.Append(Tabla(nombre,direccion,ocupacion,fnac,fing,genero,edad,edocivil,telefono,telefono_eme,escolaridad,edo,mun,edo_res,mun_res,mod,estatus));
                        body.Append(new Break());
                        body.Append(new Break());
                        body.Append(new Break());
                        body.Append(new Break());
                        body.Append(new Break());
                        body.Append(new Break());
                        body.Append(new Break());
                        body.Append(new Break());
                        body.Append(new Break());
                        if (descPaciente > 0)
                        {
                            body.Append(SubtituloSeccion("DESCRIPCIÓN DEL PACIENTE"));
                            body.Append(DescPaciente(aspecto, vestimenta, porte, movimientos, afecto));
                        }
                        body.Append(new Break());
                        body.Append(new Break());
                        if (motivocons>0) {
                            body.Append(SubtituloSeccion("MOTIVO DE LA CONSULTA"));
                            body.Append(MotivoConsulta(problema, historia, referencia, experiencia));
                        }
                        body.Append(new Break());
                        body.Append(new Break());
                        if (situacion>0) {
                            body.Append(SubtituloSeccion("SITUACIÓN ACTUAL"));
                            body.Append(Situacion(dia, ocaciones));
                        }
                        body.Append(new Break());
                        body.Append(new Break());
                        if (constelacion>0) {
                            body.Append(SubtituloSeccion("CONSTELACIÓN FAMILIAR"));
                            body.Append(Constelacion(observaciones, antecedentes, descripcion, hermanos, rivalidades, papel, uniones, normas, cambios));
                        }
                        body.Append(new Break());
                        body.Append(new Break());
                        if (recuerdos>0) {
                            body.Append(SubtituloSeccion("RECUERDOS TEMPRANOS"));
                            body.Append(RecuerdosTemp(recuerdo));
                        }                    
                        body.Append(new Break());
                        body.Append(new Break());
                        if (historiaPer > 0) {
                            body.Append(SubtituloSeccion("HISTORIA PERSONAL"));
                            body.Append(HistoriaPer(embarazo, inicio, infancia, ninez, adolecencia, adulta, avanzada, alimentacion, sueno, enfermedades, lesiones, opinion));
                        }
                        body.Append(new Break());
                        body.Append(new Break());
                        if (escolar>0) {
                            body.Append(SubtituloSeccion("ESCOLARIDAD"));
                            body.Append(Escolaridad(primaria, secundaria, preparatoria, universidad, otra, relacion, rendimiento, cambio, evaluacion));
                        }                  
                        body.Append(new Break());
                        body.Append(new Break());
                        if (diversion > 0) {
                            body.Append(SubtituloSeccion("DIVERSIÓN E INTERESES"));
                            body.Append(Diversion(lectura, practicas, pertenencia));
                        }
                        body.Append(new Break());
                        body.Append(new Break());
                        if (ajustes>0) {
                            body.Append(SubtituloSeccion("AJUSTES SOCIALES"));
                            body.Append(Ajustes(relacionesint, amistades, sentir, novios));
                        }
                        body.Append(new Break());
                        body.Append(new Break());
                        if (desarrollo > 0) {
                            body.Append(SubtituloSeccion("DESARROLLO SEXUAL"));
                            body.Append(DesarrolloSex(nociones, contacto, interes, mast, homo, relpre));
                        }
                        body.Append(new Break());
                        body.Append(new Break());
                        if (datosmar>0) {
                            body.Append(SubtituloSeccion("DATOS MARITALES"));
                            body.Append(DatosMaritales(noviazgo, expectativas, descon, eventos, hijos, interaccion, familia));
                        }                       
                        body.Append(new Break());
                        body.Append(new Break());
                        if (descsimismo>0) {
                            body.Append(SubtituloSeccion("DESCRIPCIÓN DE SÍ MISMO"));
                            body.Append(DescSimismo(afuera, demas, preocupaciones, metas, sido, crisis, triunfo, problemas));
                        }                      
                        body.Append(new Break());
                        body.Append(new Break());
                        if (estadomen>0) {
                            body.Append(SubtituloSeccion("ESTADO MENTAL"));
                            body.Append(EstadoMental(estadocon, orientacion, afectividad, asociaciones, contenido, percepcion, funcionamiento, juicio, insight, madurez));
                        }                    
                        body.Append(new Break());
                        body.Append(new Break());
                        if (diagnostico>0) {
                            body.Append(SubtituloSeccion("DIAGNÓSTICO"));
                            body.Append(Diagnostico(cognitivo, psicometrico, diagnostico_, primarioConv, especifico, pronostico));
                        }
                        body.Append(new Break());
                        body.Append(new Break());
                        if (sessiones.Count > 0)
                        {
                            body.Append(SubtituloSeccion("PSICOTERAPIA"));
                            foreach (var element in sessiones)
                            {
                                body.Append(Psicoterapia(element.pac_psico_desc, element.pac_psico_texto,element.pac_psico_intervencion,element.pac_psico_tecnicas,element.pac_psico_resultados,element.pac_psico_recomenda,element.pac_psico_observaciones));
                            
                            }
                        }
                    

                        doc.Append(body);

                        wordDoc.MainDocumentPart.Document = doc;

                        wordDoc.Close();
                        buffer = stream.ToArray();
                        var contentLength = buffer.Length;

                        var statuscode = HttpStatusCode.OK;
                        response = Request.CreateResponse(statuscode);
                        response.Content = new StreamContent(new MemoryStream(buffer));
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/msword");
                        response.Content.Headers.ContentLength = contentLength;
                        ContentDispositionHeaderValue contentDisposition = null;
                        string filename = nombre.Replace(" ", "_");
                        string filenamedoc = filename + ".docx";
                        if (ContentDispositionHeaderValue.TryParse("inline; filename="+filenamedoc, out contentDisposition))
                        {
                            response.Content.Headers.ContentDisposition = contentDisposition;
                        }
                        else
                        {
                            //var statuscode = HttpStatusCode.NotFound;
                            // var message = String.Format("Unable to find file. file \"{0}\" may not exist.");
                            // var responseData = responseDataFactory.CreateWithOnlyMetadata(statuscode, message);
                            response = Request.CreateResponse((HttpStatusCode.NotFound));
                        }
                    }
                    //return File(mem.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "ABC.docx");
                    return response;
                }

            }
            
   
        }
    }
}
