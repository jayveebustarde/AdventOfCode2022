"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const fs_1 = require("fs");
console.log('Hello world');
var pick;
(function (pick) {
    pick[pick["A"] = 1] = "A";
    pick[pick["B"] = 2] = "B";
    pick[pick["C"] = 3] = "C";
    pick[pick["X"] = 0] = "X";
    pick[pick["Y"] = 3] = "Y";
    pick[pick["Z"] = 6] = "Z";
})(pick || (pick = {}));
class FirstRound {
    constructor(opponent, yourself) {
        this.result = 0;
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
    constructor(opponent, points) {
        this.result = 0;
        this.result = 0;
        if (opponent && points) {
            const o = Number(pick[opponent].toString());
            const p = Number(pick[points].toString());
            let mypick;
            if (p === 3) {
                mypick = o;
            }
            else if (p === 0) {
                mypick = o === 1 ? 3 : o - 1;
            }
            else {
                mypick = o === 3 ? 1 : o + 1;
            }
            this.result = p + mypick;
        }
    }
}
let totalScore = 0;
let cnt = 0;
(0, fs_1.readFileSync)("input", 'utf-8')
    .split(/\r?\n/)
    .forEach(line => {
    const rnd = new SecondRound(line[0], line[2]);
    totalScore += rnd.result;
    cnt++;
});
console.log(totalScore, cnt);
//# sourceMappingURL=app.js.map