//EventListeners
function startApp() {
    let toggleThemeButton = document.querySelector('#switch')
    toggleThemeButton.addEventListener('click', toggleTheme)

    let toggleButton = document.querySelector('#toggle');
    toggleButton.addEventListener('click', openMenu)
}

//Funcion toggle toggleTheme
function toggleTheme() {
    const cambiarIcono = document.getElementById('switch')

    document.body.classList.toggle('dark');
    cambiarIcono.textContent = cambiarIcono.textContent === 'clear_day' ? 'clear_night' : 'clear_day';
}

// Función para abrir el menú

let menu = document.querySelector('#menu-icon');
let sidenavbar = document.querySelector('.side-navbar');
let content = document.querySelector('.content');

menu.onclick = () => {
    sidenavbar.classList.toggle('active');
    content.classList.toggle('active');
}

// -------Mostrar fecha y hora actual y Actualizar la hora cada segundo (1000 milisegundos)------------
function updateClock() {
    let currentTime = new Date();
    document.getElementById("hora").innerHTML = currentTime.toLocaleTimeString();
}
setInterval(updateClock, 1000);

let currentDay = new Date();
let fecha = `${currentDay.getDate().toString().padStart(2, '0')}/${(currentDay.getMonth() + 1).toString().padStart(2, '0')}/${currentDay.getFullYear().toString().substr(-2)}`;
document.getElementById('fecha').innerHTML = fecha;

window.addEventListener('load', startApp)