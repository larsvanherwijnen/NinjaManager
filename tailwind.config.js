/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Web/Views/**/*.cshtml'
  ],
  theme: {
    extend: {},
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: ["emerald"]
  }
}