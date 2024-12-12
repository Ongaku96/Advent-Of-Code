
<<<<<<< HEAD
retriveData().then((response: NumberPair[] | null) => {
    if (!response) return;
    console.log(response.reduce((sum, e) => sum + Math.abs(e.first - e.second), 0));
});


async function retriveData(): Promise<NumberPair[] | null> {
    try {
        let response = await fetch("https://adventofcode.com/2024/day/1/input").catch(ex => { throw ex; });
        if (!response.ok) return null;
        let text = await response.text();
        let data = parseNumberPairs(text);
        return data;
    } catch (ex) { console.error(ex); return null; }
}

interface NumberPair {
    first: number;
    second: number;
}

function parseNumberPairs(text: string): NumberPair[] {
    let first: number[] = [];
    let second: number[] = [];

    const regex = /(\d+)\s+(\d+)/g;
    const matches = text.matchAll(regex);

    [...matches].map(match => {
        first.push(Number(match[1])),
        second.push(Number(match[2]))
    });

    first.sort((a: number, b: number) => { return a - b; });
    second.sort((a: number, b: number) => { return a - b; });

    return first.map((e, i) => ({ 
        first: e,
        second: second.length > i ? second[i] : e
    }));

}
=======
retriveData().then((response: NumberPair[] | null) => {
    if (!response) return;
    console.log(response.reduce((sum, e) => sum + Math.abs(e.first - e.second), 0));
});


async function retriveData(): Promise<NumberPair[] | null> {
    try {
        let response = await fetch("./database.txt").catch(ex => { throw ex; });
        if (!response.ok) return null;
        let text = await response.text();
        let data = parseNumberPairs(text);
        return data;
    } catch (ex) { console.error(ex); return null; }
}

interface NumberPair {
    first: number;
    second: number;
}

function parseNumberPairs(text: string): NumberPair[] {
    let first: number[] = [];
    let second: number[] = [];

    const regex = /(\d+)\s+(\d+)/g;
    const matches = text.matchAll(regex);

    [...matches].map(match => {
        first.push(Number(match[1])),
            second.push(Number(match[2]))
    });

    first.sort((a: number, b: number) => { return a - b; });
    second.sort((a: number, b: number) => { return a - b; });

    return first.map((e, i) => ({
        first: e,
        second: second.length > i ? second[i] : e
    }));

}
>>>>>>> a6dc5716a4307dd60bcc9b924c0fbf33d06d0c72
