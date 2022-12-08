import { readFileSync } from "fs";

console.log('Hello world');
enum pick {
    A = 1,
    B = 2,
    C = 3,
    X = 0,
    Y = 3,
    Z = 6
}
class FirstRound {
    public result: number = 0;
    constructor(
        opponent: any,
        yourself: any,
    ) {
        this.result = 0;
        if (opponent && yourself) { 
            const o = Number(pick[opponent].toString());
            const y = Number(pick[yourself].toString());
            let score;

            if (o - y === -2)
                score = 0;
            else if (y - o === -2)
                score = 6;
            else if (y === o)
                score = 3;
            else
                score = o > y ? 0 : 6;

            this.result = score + y;
        }
    }
}
class SecondRound {
    public result: number = 0;
    constructor(
        opponent: any,
        points: any,
    ) {
        this.result = 0;
        if (opponent && points) {
            const o = Number(pick[opponent].toString());
            const p = Number(pick[points].toString());
            let mypick;
            if (p === 3) {
                mypick = o;
            } else if (p === 0) {
                mypick = o === 1 ? 3 : o - 1;
            } else {
                mypick = o === 3 ? 1 : o + 1;
            }
            this.result = p + mypick;
        }
    }
}
let totalScore = 0;
let cnt = 0;
readFileSync("input", 'utf-8')
    .split(/\r?\n/)
    .forEach(line => {
        const rnd = new SecondRound(line[0], line[2]);
        totalScore += rnd.result;
        cnt++;
    });
console.log(totalScore, cnt);