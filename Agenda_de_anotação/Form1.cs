using Agenda_de_anotacao;
namespace Agenda_de_anotação
{
    public partial class frmAgendaAnotacao : Form
    {
        private operacaoEnum acao;
        public frmAgendaAnotacao()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(true);
            AlterarBotoesIncluirAlterarExcluir(false);
            AlterarEstadoCampos(true);
            acao = operacaoEnum.INCLUIR;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que quer deletar esse item?","Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int indiceExcluido = lbxAnotacao.SelectedIndex;
                lbxAnotacao.SelectedIndex = 0;
                lbxAnotacao.Items.RemoveAt(indiceExcluido);       
                List<Nota> notasList = new List<Nota>();
                foreach(Nota nota in lbxAnotacao.Items)
                {
                    notasList.Add(nota);
                }
                ManipuladorDeArquivos.EscreverArquivo(notasList);
                CarregarListaDeNotas();
                LimparCampos();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void frmAgendaAnotacao_Shown(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(false);
            AlterarBotoesIncluirAlterarExcluir(true);
            CarregarListaDeNotas();
            AlterarEstadoCampos(false);
        }

        private void AlterarBotoesSalvarECancelar(bool estado)
        {
            btnSalvar.Enabled = estado;
            btnCancelar.Enabled = estado;
        }

        private void AlterarBotoesIncluirAlterarExcluir(bool estado)
        {
            btnIncluir.Enabled = estado;
            btnAlterar.Enabled = estado;
            btnDeletar.Enabled = estado;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(true);
            AlterarBotoesIncluirAlterarExcluir(false);
            AlterarEstadoCampos(true);
            acao = operacaoEnum.ALTERAR;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(false);
            AlterarBotoesIncluirAlterarExcluir(true);
            AlterarEstadoCampos(false);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Nota nota = new Nota
            {
                Title = txbtitle.Text,
                Text = richTextBox2.Text,
            };
            List<Nota> notaList = new List<Nota>();
            foreach (Nota notaDaLista in lbxAnotacao.Items)
            {
                notaList.Add(notaDaLista);
            }
            if (acao == operacaoEnum.INCLUIR)
            {
                notaList.Add(nota);
            }            
            else
            {
                int indice = lbxAnotacao.SelectedIndex;
                notaList.RemoveAt(indice);
                notaList.Insert(indice, nota);
            }
           
            ManipuladorDeArquivos.EscreverArquivo(notaList);
            CarregarListaDeNotas();
            AlterarBotoesSalvarECancelar(false);
            AlterarBotoesIncluirAlterarExcluir(true);
            LimparCampos();
            AlterarEstadoCampos(false);

        }
        private void CarregarListaDeNotas()
        {
            lbxAnotacao.Items.Clear();
            lbxAnotacao.Items.AddRange(ManipuladorDeArquivos.LerArquivo().ToArray());
            lbxAnotacao.SelectedIndex = 0;
        }
        private void LimparCampos()
        {
            txbtitle.Text = "";
            richTextBox2.Text = "";
        }

        private void AlterarEstadoCampos(bool estado)
        {
            txbtitle.Enabled = estado;
            richTextBox2.Enabled = estado;
        }

        private void lbxAnotacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nota nota = (Nota)lbxAnotacao.Items[lbxAnotacao.SelectedIndex];
            txbtitle.Text = nota.Title;
            richTextBox2.Text = nota.Text;
        }
    }
}