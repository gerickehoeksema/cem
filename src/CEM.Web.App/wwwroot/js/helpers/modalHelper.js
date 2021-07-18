let modalSize = {
    default: '',
    small: 'modal-sm',
    large: 'modal-lg'
}

class ModalHelper {
    constructor(id, size, header, body, footer) {
        this.id = id; // Modal id
        this.size = size; // modal-lg class
        this.header = header; // header html
        this.body = body; // body html
        this.footer = footer; // footer html

        this.inject();
    }
}

/**
 * Build modal with defined properties
 */
ModalHelper.prototype.build = () => {
    return `
        <div class="modal fade" id="${this.id}" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="staticBackdrop" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered  modal-dialog-scrollable ${this.size}" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        ${this.header}
                    </div>
                    <div class="modal-body">
                        ${this.body}
                    </div>
                    <div class="modal-footer">
                        ${this.footer}
                    </div>
                </div>
            </div>
        </div>
    `;
};

/**
 * Inject modal element into DOM
 */
ModalHelper.prototype.inject = () => {
    // check if modal exist else inject into DOM
    const modal = document.querySelector(`#${this.id}`)
    if (!modal) {
        document
            .querySelector('body')
            .insertAdjacentHTML('beforeend', this.build());
    }
};

ModalHelper.prototype.updateSize = () => {

};

/**
 * Update Modal Header with Custom HTML
 * @param {string} html
 */
ModalHelper.prototype.updateHeader = (html) => {
    const header = document
        .querySelector(`#${this.id}`)
        .querySelector('.modal-header')

    header.innerHTML = html;
};

/**
 * Update Modal Body with Custom HTML
 * @param {string} html
 */
ModalHelper.prototype.updateBody = (html) => {
    const body = document
        .querySelector(`#${this.id}`)
        .querySelector('.modal-body')

    body.innerHTML = html;
};

/**
 * Update Modal Footer with Custom HTML
 * @param {string} html
 */
ModalHelper.prototype.updateFooter = (html) => {
    const footer = document
        .querySelector(`#${this.id}`)
        .querySelector('.modal-footer')

    footer.innerHTML = html;
};

/**
 * Show modal
 */
ModalHelper.prototype.show = () => {
    const modal = document
        .querySelector(`#${this.id}`)

    $(modal).modal('show');
};

/**
 * Hide modal
 */
ModalHelper.prototype.hide = () => {
    const modal = document
        .querySelector(`#${this.id}`)

    $(modal).modal('hide');
}

// Remove modal from DOM (Cleanup)
ModalHelper.prototype.remove = () => {
    const modal = document.querySelector(`#${this.id}`)
    if (!modal) {
        modal.remove();
    }
};