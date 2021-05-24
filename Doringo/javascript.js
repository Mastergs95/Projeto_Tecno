function send_email() {
    
    //Get selected option
    var opt_str = "";
    var opt = document.getElementById("option_selected").value;
    
    if (opt == 1) {
        opt_str = "Não consigo iniciar sessão na minha conta.";
    } else if (opt == 2) {
        opt_str = "Não consigo finalizar sessao na minha conta.";
    } else if (opt == 3) {
        opt_str = "Não consigo adicionar items ao carrinho.";
    } else if (opt == 4) {
        opt_str = "Não consigo aceder ao meu carrinho.";
    } else if (opt == 5) {
        opt_str = "Não consigo aceder a pagina de pagamento.";
    } else if (opt == 6) {
        opt_str = "O meu pagamento foi mal sucedido.";
    } else if (opt == 7) {
        opt_str = "Outro problema.";
    }
    //alert(opt_str);

    //Send email with every s""ingle info provided
	var title = "ola"
    //var title = document.getElementById('Subject').value;
    var msgbody = document.getElementById('Message').value;
    var link = "mailto:doringooficial@hotmail.com?" +
    "&subject=" + ("Report: " + opt_str) +
    "&body=" + ("Mensagem: " + msgbody + "\n\n\n");
    window.location.href = link;
}
