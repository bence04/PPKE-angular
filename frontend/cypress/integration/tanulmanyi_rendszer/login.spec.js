describe('Login teszt', () => {
  it('Login felület megnyitása', () => {
    cy.visit('http://localhost:4200/login')
    cy.get('[placeholder="Felhasználónév"]').type('bence')
    cy.get('[placeholder="Jelszó"]').type('bence')
    cy.get('.mat-card > .mat-focus-indicator').click()
  })
})
