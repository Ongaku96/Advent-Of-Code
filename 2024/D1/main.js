const fs = require("fs");

retriveData().then((response) => {
    if (!response) return;
    console.log(response.reduce((sum, e) => sum + Math.abs(e.first - e.second), 0));
});


async function retriveData() {
    try {
        const reader = new Promise((resolve, reject) => {
            fs.readFile("./2024/D1/database.txt", "utf8", (err, data) => {
                if (err) { reject(err); return; }
                resolve(data);
            });
        });
        let response = await reader.catch(ex => { throw ex; });
        let data = parseNumberPairs(response);
        return data;
    } catch (ex) { console.error(ex); return null; }
}

const NumberPair = {
    first: 0,
    second: 0,
}

function parseNumberPairs(text) {
    let first = [];
    let second = [];

    const regex = /(\d+)\s+(\d+)/g;
    const matches = text.matchAll(regex);

    [...matches].map(match => {
        first.push(Number(match[1])),
            second.push(Number(match[2]))
    });

    first.sort((a, b) => { return a - b; });
    second.sort((a, b) => { return a - b; });

    return first.map((e, i) => ({
        first: e,
        second: second.length > i ? second[i] : e
    }));

}