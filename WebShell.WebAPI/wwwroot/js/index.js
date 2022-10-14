const outputResult = document.querySelector(".results__list");
const commandSelect = document.querySelector(".new-command__body");
const commandPath = document.getElementById(".commandOutput");
const commandField = document.querySelector(".commands__inner");

let startPosition = -1;


document.addEventListener("DOMContentLoaded",
    async () => {
        await getCommandsRequest();
        await getCurrentLocationRequest();
        fillResultList(state.results);
        fillPathList(state.results);
    });



const createResultOutput = (resultOutput) => `
 <div class="results">
    <div class="result__item"
        <div style="white-space: pre-wrap;">${resultOutput.resultOfCommand}</div>
    </div>
</div>
`;

const createCommandPath = (path) => `
<label for="commandOutput" class="command__path"><nobr>${path.currentLocation}></nobr></label>
`;

const formatCurrentPathString = () => {
    return state.results + ">";
}

const fillPathList = (results) => {
    commandField.innerHTML = "";

    if (results.length) {
        results.forEach((result) => commandField.innerHTML = createCommandPath(result));
    }
};

const fillResultList = (results) => {
    outputResult.innerHTML = "";

    if (results.length) {
        results.forEach((result) => outputResult.innerHTML += createResultOutput(result));
    }
};

document.addEventListener("keyup",
    async function(e) {
        switch (e.which) {
        case 13:
        {
            if (/^\s+$/.test(commandSelect.value) || state.newCommand.Command === "") {
                state.results.push({ resultOfCommand: "<br>" });
                fillResultList(state.results);
                break;
            } else {
                
                await createCommandsRequest();
                
                fillResultList(state.results);
                fillPathList(state.results);
                if (state.commands.length < 20) {
                    let y = state.commands.splice(0, 0, { command: state.newCommand.Command });
                } else {
                    let x = state.commands.splice(-1, 1);
                    let y = state.commands.splice(0, 0, { command: state.newCommand.Command });
                }
                break;

            }
        }
    }
    });



commandSelect.onclickup = ((currentPosition) => () => {
    currentPosition = startPosition;

    if (0 < currentPosition < state.commands.length) {
        startPosition++;
        currentPosition++;
    }
    if (currentPosition > state.commands.length - 1) {
        startPosition--;
        currentPosition--;
    };

    if (state.commands.length === 0) {
        console.log("Haven't found commands in history");
    } else {
        commandSelect.value = state.commands[currentPosition].command;
        state.newCommand.Command = commandSelect.value;
    }
})();

commandSelect.onclickdown = ((currentPosition) => () => {
    currentPosition = startPosition;

    if (0 <= currentPosition < state.commands.length) {
        startPosition--;
        currentPosition--;
    }
    if (currentPosition < 0) {
        startPosition = 0;
        currentPosition = startPosition;
    };
    if (state.commands.length === 0) {
        console.log("Haven't found commands in history");
    } else {
        commandSelect.value = state.commands[currentPosition].command;
        state.newCommand.Command = commandSelect.value;
    }
})();

commandSelect.addEventListener("change", () => state.newCommand.Command = commandSelect.value);
commandSelect.addEventListener("change", () => startPosition = -1);

document.addEventListener("keyup",
    function(e) {
        switch (e.which) {
        case 38:
            commandSelect.onclickup();
            break;
        case 40:
            commandSelect.onclickdown();
            break;
        }
    });

commandSelect.addEventListener('keydown',
    function(e) {
        if (e.keyCode === 38 || e.keyCode === 40) {
            e.preventDefault();
        }
    });