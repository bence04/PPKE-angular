describe('Szemeszter hozzáadása', () => {
  beforeEach(() => {
    cy.login()
  })

  it('Sikeres betöltés', () => {
    cy.server().route('GET', 'http://localhost:5000/api/Szemeszterek').as('dataGetFirst');
    cy.visit('http://localhost:4200/semesters')
    cy.wait('@dataGetFirst').its('status').should('be', 200);
    cy.get('.mat-focus-indicator').click()
    cy.get('.mat-form-field-hide-placeholder > .mat-form-field-wrapper > .mat-form-field-flex > .mat-form-field-infix').click().type('teszt cypress')
    cy.get('[placeholder="Szemeszter kezdete"]').type('2020-05-26T15:00')
    cy.get('.mat-dialog-actions > .mat-raised-button').click()
    cy.wait('@dataGetFirst').its('status').should('be', 200);
    cy.get('.content').contains('teszt cypress')
  })
})
