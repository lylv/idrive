﻿var path = require('path');
var globby = require('globby');
var devMode = process.argv.indexOf('--mode=production') < 0;
var ExtraWatchWebpackPlugin = require('extra-watch-webpack-plugin');

var bundleConfig = require(path.resolve(__dirname, 'bundles.json'));

var ExtractTextPlugin = require("extract-text-webpack-plugin");
var OptimizeCssAssetsPlugin = require('optimize-css-assets-webpack-plugin');
var MergeIntoSingleFilePlugin = require('webpack-merge-and-include-globally');

var styleEntries = {};
var scriptEntries = {};
var scriptMinifyTransforms = {};
var extraWatchFiles = [];

var viewScripts = globby.sync([
    './wwwroot/view-resources/**/*.js',
    '!./wwwroot/view-resources/**/*.min.js'
]);

var viewStyles = globby.sync([
    './wwwroot/view-resources/**/*.css',
    './wwwroot/view-resources/**/*.less',
    '!./wwwroot/view-resources/**/*.min.css'
]);

var metronicScripts = globby.sync([
    './wwwroot/metronic/**/*.js',
    '!./wwwroot/metronic/**/*.min.js',
    '!./wwwroot/metronic/core/**/*.js'
]);

var metronicStyles = globby.sync([
    './wwwroot/metronic/**/*.css',
    './wwwroot/metronic/**/*.less',
    '!./wwwroot/metronic/**/*.min.css'
]);

function getFileNameFromPath(path) {
    return path.substring(path.lastIndexOf('/') + 1);
}

function processInputDefinition(input) {
    var result = [];
    for (var i = 0; i < input.length; i++) {
        var url = input[i];
        if (url.startsWith('!')) {
            result.push('!' + path.resolve(__dirname, url.substring(1)));
        } else {
            result.push(path.resolve(__dirname, url));
        }
    }

    return result;
}

function processInputDefinitionForWatch(input) {
    var result = [];
    for (var i = 0; i < input.length; i++) {
        var url = input[i];
        if (url.indexOf('node_modules') < 0) {
            if (url.startsWith('!')) {
                result.push('!' + path.resolve(__dirname, url.substring(1)));
            } else {
                result.push(path.resolve(__dirname, url));
            }
        }
    }

    return result;
}

function fillScriptBundles() {

    // User defined bundles
    for (var k = 0; k < bundleConfig.scripts.length; k++) {
        var scriptBundle = bundleConfig.scripts[k];
        scriptEntries[scriptBundle.output] = globby.sync(processInputDefinition(scriptBundle.input));
        extraWatchFiles = extraWatchFiles.concat(processInputDefinitionForWatch(scriptBundle.input));
    }

    // View scripts
    for (var i = 0; i < viewScripts.length; i++) {
        var viewScriptName = viewScripts[i].replace('./wwwroot/', '');
        scriptEntries[viewScriptName.replace('.js', '.min.js')] = [path.resolve(__dirname, viewScripts[i])];
        extraWatchFiles = extraWatchFiles.concat([path.resolve(__dirname, viewScripts[i])]);
    }

    // Metronic scripts
    for (var j = 0; j < metronicScripts.length; j++) {
        var metronicScriptName = metronicScripts[j].replace('./wwwroot/', '');
        scriptEntries[metronicScriptName.replace('.js', '.min.js')] = [path.resolve(__dirname, metronicScripts[j])];
        extraWatchFiles = extraWatchFiles.concat([path.resolve(__dirname, metronicScripts[j])]);
    }

    // Script minification
    for (var key in scriptEntries) {
        if (scriptEntries.hasOwnProperty(key)) {
            scriptMinifyTransforms[key] = function (code) {
                if (devMode) {
                    return code;
                }

                return require("uglify-js").minify(code).code;
            };
        }
    }
}

function fillStyleBundles() {
    // User defined styles
    for (var k = 0; k < bundleConfig.styles.length; k++) {
        var styleBundle = bundleConfig.styles[k];
        styleEntries[styleBundle.output] = globby.sync(processInputDefinition(styleBundle.input));
    }

    // View styles
    for (var j = 0; j < viewStyles.length; j++) {
        var viewStyleName = viewStyles[j].replace('./wwwroot/', '');

        if (viewStyleName.indexOf('.css') >= 0) {
            styleEntries[viewStyleName.replace('.css', '.min.css')] = [path.resolve(__dirname, 'wwwroot/' + viewStyleName)];
        }

        if (viewStyleName.indexOf('.less') >= 0) {
            styleEntries[viewStyleName.replace('.less', '.min.css')] = [path.resolve(__dirname, 'wwwroot/' + viewStyleName)];
        }
    }

    // Metronic styles
    for (var i = 0; i < metronicStyles.length; i++) {
		var metronicStyleName = metronicStyles[i].replace('./wwwroot/', '');

		if (metronicStyleName.indexOf('.css') >= 0) {
			styleEntries[metronicStyleName.replace('.css', '.min.css')] =
				[path.resolve(__dirname, 'wwwroot/' + metronicStyleName)];
		}

		if (metronicStyleName.indexOf('.less') >= 0) {
			styleEntries[metronicStyleName.replace('.less', '.min.css')] = [path.resolve(__dirname, 'wwwroot/' + metronicStyleName)];
		}
    }
}

function fillScriptMappings() {
    for (var k = 0; k < bundleConfig.scriptMappings.length; k++) {
        var scriptBundle = bundleConfig.scriptMappings[k];
        var inputFilesToBeCopied = globby.sync(processInputDefinition(scriptBundle.input));
        for (var j = 0; j < inputFilesToBeCopied.length; j++) {
            var outputFileName = path.join(scriptBundle.outputFolder, getFileNameFromPath(inputFilesToBeCopied[j]));
            scriptEntries[outputFileName] = [inputFilesToBeCopied[j]];
        }
    }
}

fillScriptBundles();
fillScriptMappings();
fillStyleBundles();

module.exports = {
    entry: styleEntries,
    output: {
        path: path.resolve(__dirname, 'wwwroot'),
        filename: '[name]'
    },
    module: {
        rules: [
            {
                test: /\.css$/,
                use: ExtractTextPlugin.extract({
                    fallback: "style-loader",
                    use: ['css-loader']
                })
            },
            {
                test: /\.less$/,
                use: ExtractTextPlugin.extract({
                    fallback: 'style-loader',
                    use: ['css-loader', 'less-loader']
                })
            },
            {
                test: /\.(png|svg|jpg|gif)$/,
                use: {
                    loader: 'url-loader',
                    options: {
                        name: "[name].[ext]",
                        limit: 1,
                        outputPath: '/dist/img'
                    }
                }
            },
            {
                test: /\.(woff|woff2|eot|ttf|otf)$/,
                use: {
                    loader: 'url-loader',
                    options: {
                        name: "[name].[ext]",
                        limit: 1,
                        outputPath: '/dist/fonts'
                    }
                }
            }
        ]
    },
    plugins: getPlugins()
};

function getPlugins() {
    var plugins = [new ExtractTextPlugin({
        filename: "[name]"
    }),
    new MergeIntoSingleFilePlugin({
        files: scriptEntries,
        transform: scriptMinifyTransforms
    }),
    new ExtraWatchWebpackPlugin({
        files: extraWatchFiles
    })];

    if (!devMode) {
        plugins.push(new OptimizeCssAssetsPlugin({
            assetNameRegExp: /\.css$/g,
            cssProcessor: require('cssnano'),
            cssProcessorPluginOptions: {
                preset: ['default', {
                    discardComments: {
                        removeAll: true
                    }
                }]
            },
            canPrint: true
        }));
    }

    return plugins;
}
