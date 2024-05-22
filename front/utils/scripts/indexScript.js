const randomText = document.getElementById("text-presentation");
const textContent = randomText.textContent;

randomText.innerHTML = ''; // Limpar o conteúdo original

for (let i = 0; i < textContent.length; i++) {
    const span = document.createElement('span');
    span.textContent = textContent[i];
    span.style.animationDelay = `${7 + Math.random() * 5}s`; // Ajuste a duração conforme necessário
    randomText.appendChild(span);
}

// const links = document.querySelectorAll('.header ul li')

// links.forEach(link => {
//     link.addEventListener('click', function (e) {
//         e.preventDefault();
//         var section = document.querySelector('#content' + link.value);
//         console.log(section)
//         section.scrollIntoView({ behavior: 'smooth', inline: 'start' });
//         setAllWhite(links)
//         link.style.color = "yellow"
//     });
// })

// function setAllWhite(arr) {
//     arr.forEach(value => {
//         value.style.color = "white"
//     })
// }

// const fadeElements = document.querySelectorAll('.fade-in-out');

// fadeElements.forEach((element, index) => {
//     setTimeout(() => {
//         element.style.display = 'block';
//     }, index * 4000); // Delay ajustável entre os elementos

//     setTimeout(() => {
//         element.style.display = 'none';
//     }, (index + 1) * 4000); // Tempo de exibição ajustável
// });


// const observer = new IntersectionObserver(entries => {
//     entries.forEach(entry => {
//         if (entry.isIntersecting) {
//             entry.target.classList.add('animate');
//             observer.unobserve(entry.target);
//         }
//     });
// });

// document.querySelectorAll('[data-animate-on-scroll]').forEach(item => {
//     observer.observe(item);
// });

