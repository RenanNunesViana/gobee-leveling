const playPauseBtn = document.querySelector('.play-pause-btn');
const audio = document.querySelector('#myAudio');

audio.play()

playPauseBtn.addEventListener('click', () => {
    const isPaused = playPauseBtn.dataset.isPaused;
    if (isPaused) {
        playPauseBtn.dataset.isPaused = '';
        playPauseBtn.src = './utils/svg/pause-solid.svg'
        audio.play();
    } else {
        playPauseBtn.dataset.isPaused = true
        playPauseBtn.src = './utils/svg/play-solid.svg'
        audio.pause();
    }

})