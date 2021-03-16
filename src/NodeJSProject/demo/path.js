const path = require('path')

console.log('Name file: ', path.basename(__filename));

console.log('Name dir : ' + path.dirname(__filename));

console.log('Extantion file :' + path.extname(__filename));

console.log('parse ', path.parse(__filename));

console.log('parse ', path.parse(__filename).root);

console.log(path.join(__dirname, 'serser', 'index.html'))
