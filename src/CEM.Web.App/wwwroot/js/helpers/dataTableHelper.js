class DataTableHelper {
    constructor(tableElement, columns, columnDefs, serverSide) {
        this.tableElement = tableElement;
        this.columns = columns;
        this.columnDefs = columnDefs;
        this.serverSide = serverSide;

        this.table = {};
    }
}

/**
 * Build table element into DataTableJS object
 * @param {any} ajax
 * @param {any} rowCallback
 * @param {any} createdRowCallback
 * @param {any} drawCallback
 * @param {any} serverData
 * @param {any} headerCallback
 * @param {any} footerCallback
 * @param {any} displayLength
 */
DataTableHelper.prototype.build = function (ajax, rowCallback, createdRowCallback, drawCallback, serverData, headerCallback, footerCallback, displayLength = 10) {
    this.table = $(this.tableElement).dataTable({
        dom: "<'row'<'col-xs-4 col-md-2'l><'col-xs-8 col-md-10'f><'col-sm-12'<'table-responsive't>>>\n\t\t\t<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager ext-//right'p>>",
        language: {
            processing: '<i class="fa fa-spinner fa-spin fa-2x fa-fw"></i>'
        },
        columns: this.columns,
        columnDefs: this.columnDefs,
        ajax: ajax,
        processing: true,
        serverSide: this.serverSide,
        displayLength: displayLength,
        pagingType: 'full_numbers',
        ordering: true,
        rowCallback: rowCallback,
        createdRow: createdRowCallback,
        drawCallback: drawCallback,
        ServerData: serverData,
        headerCallback: headerCallback,
        footerCallback: footerCallback,
        // lengthMenu: [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]]
    });

    return this;
};

/**
 * Re-draw DataTable
 */
DataTableHelper.prototype.draw = function () {
    this.table.api().draw();
}

/**
 * Re-draw DataTable with new URL
 */
DataTableHelper.prototype.url = function (url) {
    this.table.api().ajax.url(url).load();
}