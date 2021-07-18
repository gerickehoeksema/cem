var login = (function () {

    const setupEventListeners = () => {
        document.querySelector('#btnSignIn')
            .addEventListener('click', signIn);

    };

    const signIn = async (e) => {
        e.preventDefault();

        // TODO: Validate

        const loginModel = {
            username: document.querySelector('#inpUsername').value,
            password: document.querySelector('#inpPassword').value,
            rememberMe: document.querySelector('#remember').checked
        };

        console.log(loginModel);

        //  API Call
        try {
            const response = await fetch(`${API_BaseURL}/api/account/login`, {
                method: 'POST',
                body: JSON.stringify(loginModel),
                credentials: 'include',
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (response.status === 401) {
                utlities.displayAlert(
                    "Invalid credentials.",
                    "error",
                    "Ok, got it!",
                    "btn font-weight-bold btn-light-primary",
                    null
                );
                return;
            };

            const json = await response.json();
            if (json) {
                utlities.setCookie('token', json.token, json.expiration);
                utlities.setCookie('roles', json.roles, json.expiration);
                utlities.setCookie('userName', json.userName, json.expiration);
                utlities.setCookie('name', json.name, json.expiration);
                utlities.setCookie('lastName', json.lastName, json.expiration);
                utlities.setCookie('userId', json.userId, json.expiration);

                window.location.href = "/";
            };
        } catch (e) {
            utlities.displayAlert(
                "Sorry, login was unsuccessful, please try again.",
                "error",
                "Ok, got it!",
                "btn font-weight-bold btn-light-primary",
                null
            );
        }
    }

    return {
        init: () => {
            setupEventListeners();
        }
    }
})();

login.init();