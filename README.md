Inforce test task - photo gallery

Technical stack: 
<li>asp net core</li>
<li>angluar </li>
<li>ef core</li>
<li>xUnit</li>
</br>
user (must be authorized) can:
<li>upload image via image controller</li>
<li>create album via album controller</li>
</br>
for anonymous user implemented: 
<li>retrieve album's & image's with pagination (5 for every page)</li>
</br>
for auth, on backend used built in functionality with asp net core, in frontend part, create tokenInteceptor service which provide access to http request from angular.
</br>
for testing purposes utilized xUnit, and create some unit test for contoller functionality. 
