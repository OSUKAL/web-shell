function getCommandsRequest() {
    return fetch("/commands/get",
            {
                method: "GET",
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            })
        .then((res) => res.json())
        .then((commands) => state.commands = state.commands.concat(commands));
}

function getCurrentLocationRequest() {
    return fetch("/commands/get-location",
            {
                method: "GET",
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            })
        .then((res) => res.json())
        .then((results) => state.results = state.results.concat(results));
}

function createCommandsRequest() {
    return fetch("/commands/post",
            {
                method: "POST",
                body: JSON.stringify(state.newCommand),
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            })
        .then((res) => res.json())
        .then((results) => state.results.push(results));

}