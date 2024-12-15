const fs = require("fs");
//#region PART 1
retriveData().then((response) => {
    if (!response) return;
    let data = parseNumberPairs(response);
    let pairs = data.first.map((e, i) => ({ first: e, second: data.second.length > i ? data.second[i] : e }));
    console.log("PART 1: " + pairs.reduce((sum, e) => sum + Math.abs(e.first - e.second), 0));
});
//#endregion

//#region PART 2
retriveData().then((response) => {
    if (!response) return;
    let data = parseNumberPairs(response);
    let refs = removeDuplicates(data.first);
    counter = refs.map(item => data.second.filter(e => e === item).length);
    console.log("PART 2: " + counter.reduce((sum, e, index) => sum + e * refs[index], 0));
});

function removeDuplicates(dataset) {
    let unique = [];
    for (const item of dataset) {
        if (!unique.includes(item)) unique.push(item);
    }
    return unique;
}
//#endregion

async function retriveData() {
    try {
        const reader = new Promise((resolve, reject) => {
            fs.readFile("./2024/D1/database.txt", "utf8", (err, data) => {
                if (err) { reject(err); return; }
                resolve(data);
            });
        });
        let response = await reader.catch(ex => { throw ex; });
        return response;
    } catch (ex) { console.error(ex); return null; }
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

    return { first, second };

}