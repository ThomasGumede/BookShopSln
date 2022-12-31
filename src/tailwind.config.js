/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./BookShop/Views/**/*.cshtml", "./Pages/**/*.cshtml"],
  theme: {
    extend: {
      fontFamily: {
        poppins: ["Poppins", "sans-serif"],
        serif: ["DM Serif Display", "serif"],
      },
    },
  },
  plugins: [],
};
