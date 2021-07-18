var utlities = (function () {

    return {
        /**
         * Alert a message using Sweetalert2
         * @param {string} message
         * @param {string} icon
         * @param {string} confirmButtonText
         * @param {string} confirmButtonClass
         * @param {boolean} showDenyButton
         * @param {string} denyButtonText
         * @param {Function} callback
         */
        displayAlert: (message, icon, confirmButtonText, confirmButtonClass, showDenyButton, denyButtonText, callback) => {
            Swal.fire({
                text: message,
                icon: icon,
                buttonsStyling: true,
                confirmButtonText: confirmButtonText,
                customClass: {
                    confirmButton: confirmButtonClass
                },
                showDenyButton: showDenyButton,
                denyButtonText: denyButtonText
            }).then(result => {
                if (callback)
                    callback(result);
            });
        },
        /**
         * Display toaster
         * @param {string} tittle
         * @param {string} message
         * @param {string} icon
         * @param {number} duration
         */
        notify: (tittle, message, icon, duration) => {
            Swal.fire({
                title: tittle,
                text: message,
                icon: icon,
                toast: true,
                position: 'bottom',
                showConfirmButton: false,
                timer: duration,
                timerProgressBar: true,
            })
        },
        /**
         * Set Cookie
         * @param {string} cookieName
         * @param {string} cookieValue
         * @param {string} expiresDate
         */
        setCookie: (cookieName, cookieValue, expiresDate) => {
            var expires = "expires=" + new Date(expiresDate);
            document.cookie = cookieName + "=" + cookieValue + ";" + expires + ";path=/";
        },
        /**
         * Get Cookie
         * @param {string} cookieName
         */
        getCookie: (cookieName) => {
            var name = cookieName + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') {
                    c = c.substring(1);
                }
                if (c.indexOf(name) == 0) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        },
        /**
         * Get request headers with token
         * @param {string} method
         * @param {object} jsondata
         */
        getRequestHeaders: (method, jsondata) => {
            const headers = {
                'Content-Type': 'application/json',
                'Authorization': 'bearer ' + this.getCookie("token"),
            };

            if (method === "GET") {
                return { headers: headers };
            } else {
                return {
                    headers: headers,
                    method: method,
                    body: JSON.stringify(jsondata)
                };
            }
        },
        /**
         * Handle results after fetch
         * @param {any} result
         */
        handleFetchResult: async (result) => {
            let json = await result.json();

            let errorMessage = "";
            if (result.ok == false) {
                if (json.hasOwnProperty("errors"))
                    //errorMessage = json.errors.join("<br>"); // TODO: Improve/fix this
                    errorMessage = "An Unknown Error Has Occurred";
                else if (json.hasOwnProperty("errorMessage")) {
                    errorMessage = json.errorMessage;
                }
                else errorMessage = "An Unknown Error Has Occurred";
            }
            return { isOk: result.ok, json: json, error: errorMessage }
        }
    }
})();