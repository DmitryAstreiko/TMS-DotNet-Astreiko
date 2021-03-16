const fs = require('fs')
const path = require('path')

/*fs.mkdir(path.join(__dirname, 'test'), (err) => {
    if (err) {
        throw err
    }

    console.log('dir created');
})*/


const filepath = path.join(__dirname, 'test', 'text.txt')

/*fs.writeFile(filepath, 'Hello NodeLS', (err) => {
    if (err) {
        throw err
    }

    console.log('File created');
})

fs.appendFile(filepath, '\nHello again', (err) => {
    if (err) {
        throw err
    }

    console.log('File created');
})*/

fs.readFile(filepath, (err, content) => {
    if (err) {
        throw err
    }

    const data = Buffer.from(content)
    console.log('Content', data.toString());
})

fs.readFile(filepath, 'utf-8', (err, content) => {
    if (err) {
        throw err
    }

    console.log('Content', content);
})