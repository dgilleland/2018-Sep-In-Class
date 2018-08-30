module.exports = {
    title: '2018 Sep',
    description: 'In-Class Demos and Supporting Notes',

    markdown: {
        config: md => {
            md.set({ breaks: true })
            md.use(require('markdown-it-imsize'))
            md.use(require('markdown-it-mermaid').default) // leave default options
            md.use(require('markdown-it-checkbox'))
            md.use(require('markdown-it-kbd'))
            md.use(require('markdown-it-deflist'))
            md.use(require('markdown-it-abbr'))
            md.use(require('markdown-it-mark'))
            md.use(require('markdown-it-footnote'))
            md.use(require('markdown-it-sub'))
            md.use(require('markdown-it-sup'))
        }
    },
    base: '/2018-Sep-In-Class/',
    themeConfig: {
        // Assumes GitHub. Can also be a full GitLab url.
        repo: 'dgilleland/2018-Sep-In-Class',
        lastUpdated: 'Last Updated',
        serviceWorker: {
            updatePopup: true // Boolean | Object, default to undefined.
            // If set to true, the default text config will be: 
            // updatePopup: { 
            //    message: "New content is available.", 
            //    buttonText: "Refresh" 
            // }
        },
        nav: [
            { text: 'Home', link: '/' },
            { text: 'Teaching Schedule', link: 'https://dgilleland.github.io/new/' },
            { text: 'DMIT-1508 errata', link: '/1508/' },
            { text: 'DMIT-2018 errata', link: '/2018/' },
        ]
    }
};