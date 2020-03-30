const path = require('path');
const scriptsPath = "js/";
const resourcesPath = "css/";

module.exports = {
    pluginOptions: {
        'style-resources-loader': {
            preProcessor: 'scss',
            patterns: [
                path.resolve(__dirname, 'src/styles/_variables.scss'),
                path.resolve(__dirname, 'src/styles/_mixins.scss')
            ]
        }
    },
    productionSourceMap: false,
    css: {
        extract: {
            filename: resourcesPath + "[name].css",
            chunkFilename: resourcesPath + "[name].css"
        }
    },
    configureWebpack: {
        output: {
            filename: scriptsPath + '[name].js',
            chunkFilename: scriptsPath + '[name].js'
        }
    },
};