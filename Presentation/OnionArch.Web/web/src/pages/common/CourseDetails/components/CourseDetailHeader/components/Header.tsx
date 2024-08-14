import { Stack, Typography } from '@mui/material'

const Header = () => {
    return (
        <Stack direction="column" spacing={2}>
            <Typography variant='h3'>İngilizce Eğitimi (A1-A2)</Typography>
            <Typography variant='body1'>Bu eğitimde tam 1500 kelime öğretiyoruz. İngilizce öğrenmenin en etkili yolu, profesyonel bir öğretmenden online ingilizce kursu almak. A1-A2 seviyesinde hızlı bir başlangıç yapmak isteyenler hazırladık.</Typography>
        </Stack>
    )
}

export default Header