import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({ login, timestamp }) => (
	<li>{login} at {timestamp}</li>

);

const LoginAttemptList = ({ attempts }) => {
	const [filter, setFilter] = useState('');

	const filtered = attempts.filter(a => a.login.toLowerCase().includes(filter.toLowerCase()));

	return (
		<div className="Attempt-List-Main">
			<p>Recent activity</p>
			<input
				type="text"
				placeholder="Filter..."
				value={filter}
				onChange={(e) => setFilter(e.target.value)}
			/>
			<ul className="Attempt-List">
				{filtered.map((a, i) => (
					<LoginAttempt key={i} {...a} />
				))}
			</ul>
		</div>
	);
};

export default LoginAttemptList;
