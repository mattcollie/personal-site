const width = window.innerWidth;
const height = window.innerHeight;

$('document').ready(function(){
    const wrapper = document.getElementById('wrapper');
    const colour = new Colour();

    setInterval(function() {
        let colours = createColourCollection(colour);
        let gradients = buildWebkitLinearGradients(colours);
        document.getElementById('wrapper').style.background = gradients;
        console.log(gradients)
        console.log(document.getElementById('wrapper').style.background);
    }, 100);
});

function createColourCollection(colour) {
    let colours = [];
    for(let count = 0; count < 1; count++) {
        let rgb = colour.next();
        colours.push(rgb);
    }
    return colours;
}

function buildWebkitLinearGradients(colours) {
    return buildLinearGradients(colours, buildWebkitLinearGradient);
}

function buildLinearGradients(colours, gradientBuilder = buildLinearGradient) {
    let gredients = [];
    for(let index in colours) {
        let colour = colours[index];
        colour.degrees = [45, 315, 225, 135][index];
        colour.start =   [0 ,  10,  10, 100][index];
        colour.stop =    [70 ,  80,  80, 70][index];
        colour.alpha = 0.5;
        gredients.push(gradientBuilder(colour));
    }
    return ` ${gredients.join(', ')}; `;
}

function buildWebkitLinearGradient(colour) {
    return '-webkit-' + buildLinearGradient(colour);
}

function buildLinearGradient(colour) {
    return `linear-gradient(${colour.degrees}deg, rgb(${colour.r}, ${colour.g}, ${colour.b}) ${colour.start}%, rgb(${colour.r}, ${colour.g}, ${colour.b}) ${colour.stop}%)`;
}

function round(number) {
    return Math.round(number * 100) / 100;
}

class Colour {

    constructor() {
        this.MAX_STEP = 1603;
        this.count = 0;
        this.step = _ => this.count++ % this.MAX_STEP;
        this.r = [];
        this.g = [];
        this.b = [];
    }

    next() {
        let step = this.step();
        if(this.count <= this.MAX_STEP + 1) {
            let r = Math.floor(map(Math.sin((step / 255)) * 1000, -1000, 1000, 0, 255))
                ,g = Math.floor(map(Math.sin((step / 255) - Math.PI * 2 / 3) * 1000, -1000, 1000, 0, 255))
                ,b = Math.floor(map(Math.sin((step / 255) - Math.PI * 4 / 3) * 1000, -1000, 1000, 0, 255));
            this.r[step] = r;
            this.g[step] = g;
            this.b[step] = b;
        }

        return {
            r: this.r[step],
            g: this.g[step],
            b: this.b[step]
        };

        function map(x, inMin, inMax, outMin, outMax) {
            return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
    }

}