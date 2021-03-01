import { signout } from '../../utils/api-auth.js'

const auth = {
	parseJwt(token) {
		var base64Url = token.split('.')[1];
		var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
		var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
			return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
		}).join(''));

		return JSON.parse(jsonPayload);
	},
	isAuthenticated() {
		if (typeof window == 'undefined') return false;

		if (sessionStorage.getItem('jwt'))
			return JSON.parse(sessionStorage.getItem('jwt'));
		else return false;
	},
	authenticate(jwt, cb) {
		if (typeof window !== 'undefined')
			sessionStorage.setItem('jwt', JSON.stringify(jwt));
		cb();
	},
	signout(cb) {
		if (typeof window !== 'undefined') sessionStorage.removeItem('jwt');
		cb();
		//optional
		signout().then(data => {
			document.cookie = 't=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
		});
	},
	isAdmin() {
		if (typeof window == 'undefined') return false;

		if (sessionStorage.getItem('jwt')) {
			try {
				var claims = auth.parseJwt(JSON.parse(sessionStorage.getItem('jwt')).jwtAccessToken);
				return (claims.IsAdmin == "True");
			} catch {
				return false;
            }
        }
	}
};

export default auth;
