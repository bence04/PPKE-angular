describe('Szemeszter törlése', () => {
  beforeEach(() => {
    cy.login()
  })

  it('Sikeres betöltés', () => {
    cy.server().route('GET', 'http://localhost:5000/api/Szemeszterek').as('dataGetFirst');
    cy.visit('http://localhost:4200/semesters')
    cy.wait('@dataGetFirst').its('status').should('be', 200);
    cy.get(':nth-child(3) > .action-buttons > :nth-child(1)').click()
    cy.wait('@dataGetFirst').its('status').should('be', 200);
  })
})
