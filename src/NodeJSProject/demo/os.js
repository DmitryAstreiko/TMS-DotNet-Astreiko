const os = require('os')

console.log('os ', os.platform());

console.log('processor ', os.arch());

console.log('info cpu', os.cpus());

console.log('memory', os.freemem());

console.log('totalmem ', os.totalmem());

console.log('homw dir', os.homedir());

console.log('time in', os.uptime());