export function formatDuration(durationInSeconds: number) {
    var hours = Math.trunc(durationInSeconds / 3600) 
    var minutes = Math.trunc(durationInSeconds / 60)
    var seconds = durationInSeconds % 60

    let formattedDuration = "";

    if (hours > 0) {
        formattedDuration += `${hours}h`;
    }
    if (minutes > 0) {
        if (formattedDuration) {
            formattedDuration += ` `;
        }
        formattedDuration += `${minutes}m`;
    }
    if (seconds > 0) {
        if (formattedDuration) {
            formattedDuration += ` `;
        }
        formattedDuration += `${seconds}s`
    }

    return formattedDuration;
}