// ***********************************************
// This example commands.js shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add("login", (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add("drag", { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add("dismiss", { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite("visit", (originalFn, url, options) => { ... })

Cypress.Commands.add('login', () => {
  window.localStorage.setItem('jwt', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJhZDhhMDQxYy1mMjFmLTQ2Y2EtYmZmNS04MDIwM2Y1OGY2MWYiLCJzdWIiOiJiZW5jZUBiZW5jZS5odSIsIm5iZiI6MTU5MDQ5MTMxMywiZXhwIjoxNTkwNDkzMTEzLCJpc3MiOiJUUiIsImF1ZCI6IlRSIn0.wOwBPAIcsSbhjmEqltVBAolNae16LEzZCxHWB8o3o9k')
})
