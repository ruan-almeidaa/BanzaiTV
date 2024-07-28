$(document).ready(function() {
    let table = new DataTable('#tabela', {
        // Configurações do DataTables
        paging: true,
        searching: true,
        ordering: true,
        info: true,
        lengthChange: true,
        language: {
            // Personalizar textos e mensagens de interface
            paginate: {
                previous: "Anterior",
                next: "Próximo"
            },
            search: "Buscar:",
            lengthMenu: "Mostrar até _MENU_linhas",
            info: "Mostrando da linha _START_ até _END_ num total de _TOTAL_ linhas",
            infoEmpty: "Mostrando 0 a 0 de 0 entradas",
            emptyTable: "Nenhum dado disponível na tabela"
        }
    });
});
