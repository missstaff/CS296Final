
# ZAP Scanning Report

Generated on Tue, 9 Mar 2021 12:33:34


## Summary of Alerts

| Risk Level | Number of Alerts |
| --- | --- |
| High | 1 |
| Medium | 2 |
| Low | 18 |
| Informational | 9 |

## Alerts

| Name | Risk Level | Number of Instances |
| --- | --- | --- | 
| Cross Site Scripting (Reflected) | High | 2 | 
| Cross-Domain Misconfiguration | Medium | 1 | 
| X-Frame-Options Header Not Set | Medium | 244 | 
| Absence of Anti-CSRF Tokens | Low | 104 | 
| Application Error Disclosure | Low | 33 | 
| Cookie Without Secure Flag | Low | 3 | 
| Incomplete or No Cache-control and Pragma HTTP Header Set | Low | 286 | 
| Server Leaks Information via "X-Powered-By" HTTP Response Header Field(s) | Low | 411 | 
| X-Content-Type-Options Header Missing | Low | 284 | 
| Charset Mismatch  | Informational | 1 | 
| Information Disclosure - Suspicious Comments | Informational | 2 | 
| Loosely Scoped Cookie | Informational | 4 | 
| Timestamp Disclosure - Unix | Informational | 276 | 

## Alert Detail


  
  
  
  
### Cross Site Scripting (Reflected)
##### High (Low)
  
  
  
  
#### Description
<p>Cross-site Scripting (XSS) is an attack technique that involves echoing attacker-supplied code into a user's browser instance. A browser instance can be a standard web browser client, or a browser object embedded in a software product such as the browser within WinAmp, an RSS reader, or an email client. The code itself is usually written in HTML/JavaScript, but may also extend to VBScript, ActiveX, Java, Flash, or any other browser-supported technology.</p><p>When an attacker gets a user's browser to execute his/her code, the code will run within the security context (or zone) of the hosting web site. With this level of privilege, the code has the ability to read, modify and transmit any sensitive data accessible by the browser. A Cross-site Scripted user could have his/her account hijacked (cookie theft), their browser redirected to another location, or possibly shown fraudulent content delivered by the web site they are visiting. Cross-site Scripting attacks essentially compromise the trust relationship between a user and the web site. Applications utilizing browser object instances which load content from the file system may execute code under the local machine zone allowing for system compromise.</p><p></p><p>There are three types of Cross-site Scripting attacks: non-persistent, persistent and DOM-based.</p><p>Non-persistent attacks and DOM-based attacks require a user to either visit a specially crafted link laced with malicious code, or visit a malicious web page containing a web form, which when posted to the vulnerable site, will mount the attack. Using a malicious form will oftentimes take place when the vulnerable resource only accepts HTTP POST requests. In such a case, the form can be submitted automatically, without the victim's knowledge (e.g. by using JavaScript). Upon clicking on the malicious link or submitting the malicious form, the XSS payload will get echoed back and will get interpreted by the user's browser and execute. Another technique to send almost arbitrary requests (GET and POST) is by using an embedded client, such as Adobe Flash.</p><p>Persistent attacks occur when the malicious code is submitted to a web site where it's stored for a period of time. Examples of an attacker's favorite targets often include message board posts, web mail messages, and web chat software. The unsuspecting user is not required to interact with any additional site/link (e.g. an attacker site or a malicious link sent via email), just simply view the web page containing the code.</p>
  
  
  
* URL: [https://localhost:44325/Account/LogIn](https://localhost:44325/Account/LogIn)
  
  
  * Method: `POST`
  
  
  * Parameter: `RememberMe`
  
  
  * Attack: `<script>alert(1);</script>`
  
  
  * Evidence: `<script>alert(1);</script>`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn?returnUrl=%2FHome%2FForum](https://localhost:44325/Account/LogIn?returnUrl=%2FHome%2FForum)
  
  
  * Method: `POST`
  
  
  * Parameter: `RememberMe`
  
  
  * Attack: `<script>alert(1);</script>`
  
  
  * Evidence: `<script>alert(1);</script>`
  
  
  
  
Instances: 2
  
### Solution
<p>Phase: Architecture and Design</p><p>Use a vetted library or framework that does not allow this weakness to occur or provides constructs that make this weakness easier to avoid.</p><p>Examples of libraries and frameworks that make it easier to generate properly encoded output include Microsoft's Anti-XSS library, the OWASP ESAPI Encoding module, and Apache Wicket.</p><p></p><p>Phases: Implementation; Architecture and Design</p><p>Understand the context in which your data will be used and the encoding that will be expected. This is especially important when transmitting data between different components, or when generating outputs that can contain multiple encodings at the same time, such as web pages or multi-part mail messages. Study all expected communication protocols and data representations to determine the required encoding strategies.</p><p>For any data that will be output to another web page, especially any data that was received from external inputs, use the appropriate encoding on all non-alphanumeric characters.</p><p>Consult the XSS Prevention Cheat Sheet for more details on the types of encoding and escaping that are needed.</p><p></p><p>Phase: Architecture and Design</p><p>For any security checks that are performed on the client side, ensure that these checks are duplicated on the server side, in order to avoid CWE-602. Attackers can bypass the client-side checks by modifying values after the checks have been performed, or by changing the client to remove the client-side checks entirely. Then, these modified values would be submitted to the server.</p><p></p><p>If available, use structured mechanisms that automatically enforce the separation between data and code. These mechanisms may be able to provide the relevant quoting, encoding, and validation automatically, instead of relying on the developer to provide this capability at every point where output is generated.</p><p></p><p>Phase: Implementation</p><p>For every web page that is generated, use and specify a character encoding such as ISO-8859-1 or UTF-8. When an encoding is not specified, the web browser may choose a different encoding by guessing which encoding is actually being used by the web page. This can cause the web browser to treat certain sequences as special, opening up the client to subtle XSS attacks. See CWE-116 for more mitigations related to encoding/escaping.</p><p></p><p>To help mitigate XSS attacks against the user's session cookie, set the session cookie to be HttpOnly. In browsers that support the HttpOnly feature (such as more recent versions of Internet Explorer and Firefox), this attribute can prevent the user's session cookie from being accessible to malicious client-side scripts that use document.cookie. This is not a complete solution, since HttpOnly is not supported by all browsers. More importantly, XMLHTTPRequest and other powerful browser technologies provide read access to HTTP headers, including the Set-Cookie header in which the HttpOnly flag is set.</p><p></p><p>Assume all input is malicious. Use an "accept known good" input validation strategy, i.e., use an allow list of acceptable inputs that strictly conform to specifications. Reject any input that does not strictly conform to specifications, or transform it into something that does. Do not rely exclusively on looking for malicious or malformed inputs (i.e., do not rely on a deny list). However, deny lists can be useful for detecting potential attacks or determining which inputs are so malformed that they should be rejected outright.</p><p></p><p>When performing input validation, consider all potentially relevant properties, including length, type of input, the full range of acceptable values, missing or extra inputs, syntax, consistency across related fields, and conformance to business rules. As an example of business rule logic, "boat" may be syntactically valid because it only contains alphanumeric characters, but it is not valid if you are expecting colors such as "red" or "blue."</p><p></p><p>Ensure that you perform input validation at well-defined interfaces within the application. This will help protect the application even if a component is reused or moved elsewhere.</p>
  
### Other information
<p>Raised with LOW confidence as the Content-Type is not HTML</p>
  
### Reference
* http://projects.webappsec.org/Cross-Site-Scripting
* http://cwe.mitre.org/data/definitions/79.html

  
#### CWE Id : 79
  
#### WASC Id : 8
  
#### Source ID : 1

  
  
  
  
### Cross-Domain Misconfiguration
##### Medium (Medium)
  
  
  
  
#### Description
<p>Web browser data loading may be possible, due to a Cross Origin Resource Sharing (CORS) misconfiguration on the web server</p>
  
  
  
* URL: [https://location.services.mozilla.com/v1/country?key=7e40f68c-7938-4c5d-9f95-e61647c213eb](https://location.services.mozilla.com/v1/country?key=7e40f68c-7938-4c5d-9f95-e61647c213eb)
  
  
  * Method: `GET`
  
  
  * Evidence: `Access-Control-Allow-Origin: *`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that sensitive data is not available in an unauthenticated manner (using IP address white-listing, for instance).</p><p>Configure the "Access-Control-Allow-Origin" HTTP header to a more restrictive set of domains, or remove all CORS headers entirely, to allow the web browser to enforce the Same Origin Policy (SOP) in a more restrictive manner.</p>
  
### Other information
<p>The CORS misconfiguration on the web server permits cross-domain read requests from arbitrary third party domains, using unauthenticated APIs on this domain. Web browser implementations do not permit arbitrary third parties to read the response from authenticated APIs, however. This reduces the risk somewhat. This misconfiguration could be used by an attacker to access data that is available in an unauthenticated manner, but which uses some other form of security, such as IP address white-listing.</p>
  
### Reference
* http://www.hpenterprisesecurity.com/vulncat/en/vulncat/vb/html5_overly_permissive_cors_policy.html

  
#### CWE Id : 264
  
#### WASC Id : 14
  
#### Source ID : 3

  
  
  
  
### X-Frame-Options Header Not Set
##### Medium (Medium)
  
  
  
  
#### Description
<p>X-Frame-Options header is not included in the HTTP response to protect against 'ClickJacking' attacks.</p>
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP](https://localhost:44325/Novels?currentFilter=ZAP)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F445](https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F445)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&sortOrder=Date](https://localhost:44325/Movies?currentFilter=ZAP&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies/Details/659](https://localhost:44325/Movies/Details/659)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&sortOrder=Genre](https://localhost:44325/Novels?currentFilter=ZAP&sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F116](https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F116)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=1&sortOrder=Rating](https://localhost:44325/Movies?pageNumber=1&sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies/Details/547](https://localhost:44325/Movies/Details/547)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FNovels%2FEdit%2F2](https://localhost:44325/Account/Login?ReturnUrl=%2FNovels%2FEdit%2F2)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&sortOrder=Genre](https://localhost:44325/Movies?currentFilter=ZAP&sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FNovels%2FEdit%2F1](https://localhost:44325/Account/Login?ReturnUrl=%2FNovels%2FEdit%2F1)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=3&sortOrder=Genre](https://localhost:44325/Movies?pageNumber=3&sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&sortOrder=genre_desc](https://localhost:44325/Movies?currentFilter=ZAP&sortOrder=genre_desc)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies](https://localhost:44325/Movies)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=3&sortOrder=Rating](https://localhost:44325/Novels?pageNumber=3&sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=2&sortOrder=name_desc](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=2&sortOrder=name_desc)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=3&sortOrder=Date](https://localhost:44325/Movies?pageNumber=3&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Novels?sortOrder=Publisher](https://localhost:44325/Novels?sortOrder=Publisher)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F550](https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F550)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&sortOrder=Date](https://localhost:44325/Novels?currentFilter=ZAP&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
Instances: 244
  
### Solution
<p>Most modern Web browsers support the X-Frame-Options HTTP header. Ensure it's set on all web pages returned by your site (if you expect the page to be framed only by pages on your server (e.g. it's part of a FRAMESET) then you'll want to use SAMEORIGIN, otherwise if you never expect the page to be framed, you should use DENY. Alternatively consider implementing Content Security Policy's "frame-ancestors" directive. </p>
  
### Reference
* https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Absence of Anti-CSRF Tokens
##### Low (Medium)
  
  
  
  
#### Description
<p>No Anti-CSRF tokens were found in a HTML submission form.</p><p>A cross-site request forgery is an attack that involves forcing a victim to send an HTTP request to a target destination without their knowledge or intent in order to perform an action as the victim. The underlying cause is application functionality using predictable URL/form actions in a repeatable way. The nature of the attack is that CSRF exploits the trust that a web site has for a user. By contrast, cross-site scripting (XSS) exploits the trust that a user has for a web site. Like XSS, CSRF attacks are not necessarily cross-site, but they can be. Cross-site request forgery is also known as CSRF, XSRF, one-click attack, session riding, confused deputy, and sea surf.</p><p></p><p>CSRF attacks are effective in a number of situations, including:</p><p>    * The victim has an active session on the target site.</p><p>    * The victim is authenticated via HTTP auth on the target site.</p><p>    * The victim is on the same local network as the target site.</p><p></p><p>CSRF has primarily been used to perform an action against a target site using the victim's privileges, but recent techniques have been discovered to disclose information by gaining access to the response. The risk of information disclosure is dramatically increased when the target site is vulnerable to XSS, because XSS can be used as a platform for CSRF, allowing the attack to operate within the bounds of the same-origin policy.</p>
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=2&sortOrder=date_desc](https://localhost:44325/Novels?pageNumber=2&sortOrder=date_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=1&sortOrder=Genre](https://localhost:44325/Novels?pageNumber=1&sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=2&sortOrder=Director](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=2&sortOrder=Director)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Movies">`
  
  
  
  
* URL: [https://localhost:44325/Novels?sortOrder=Rating](https://localhost:44325/Novels?sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=2&sortOrder=Publisher](https://localhost:44325/Novels?pageNumber=2&sortOrder=Publisher)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=2&sortOrder=Date](https://localhost:44325/Movies?pageNumber=2&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Movies">`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP](https://localhost:44325/Movies?currentFilter=ZAP)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Movies">`
  
  
  
  
* URL: [https://localhost:44325/Novels?sortOrder=Genre](https://localhost:44325/Novels?sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Novels?SearchString=ZAP](https://localhost:44325/Novels?SearchString=ZAP)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=1&sortOrder=Date](https://localhost:44325/Novels?pageNumber=1&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Novels?sortOrder=genre_desc](https://localhost:44325/Novels?sortOrder=genre_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&sortOrder=genre_desc](https://localhost:44325/Movies?currentFilter=ZAP&sortOrder=genre_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Movies">`
  
  
  
  
* URL: [https://localhost:44325/Novels?sortOrder=Date](https://localhost:44325/Novels?sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=2&sortOrder=Genre](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=2&sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=3&sortOrder=name_desc](https://localhost:44325/Novels?pageNumber=3&sortOrder=name_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Novels?sortOrder=name_desc](https://localhost:44325/Novels?sortOrder=name_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=2](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=2)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Movies?sortOrder=Director](https://localhost:44325/Movies?sortOrder=Director)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Movies">`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&sortOrder=Publisher](https://localhost:44325/Novels?currentFilter=ZAP&sortOrder=Publisher)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=3](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=3)
  
  
  * Method: `GET`
  
  
  * Evidence: `<form method="get" action="/Novels">`
  
  
  
  
Instances: 104
  
### Solution
<p>Phase: Architecture and Design</p><p>Use a vetted library or framework that does not allow this weakness to occur or provides constructs that make this weakness easier to avoid.</p><p>For example, use anti-CSRF packages such as the OWASP CSRFGuard.</p><p></p><p>Phase: Implementation</p><p>Ensure that your application is free of cross-site scripting issues, because most CSRF defenses can be bypassed using attacker-controlled script.</p><p></p><p>Phase: Architecture and Design</p><p>Generate a unique nonce for each form, place the nonce into the form, and verify the nonce upon receipt of the form. Be sure that the nonce is not predictable (CWE-330).</p><p>Note that this can be bypassed using XSS.</p><p></p><p>Identify especially dangerous operations. When the user performs a dangerous operation, send a separate confirmation request to ensure that the user intended to perform that operation.</p><p>Note that this can be bypassed using XSS.</p><p></p><p>Use the ESAPI Session Management control.</p><p>This control includes a component for CSRF.</p><p></p><p>Do not use the GET method for any request that triggers a state change.</p><p></p><p>Phase: Implementation</p><p>Check the HTTP Referer header to see if the request originated from an expected page. This could break legitimate functionality, because users or proxies may have disabled sending the Referer for privacy reasons.</p>
  
### Other information
<p>No known Anti-CSRF token [anticsrf, CSRFToken, __RequestVerificationToken, csrfmiddlewaretoken, authenticity_token, OWASP_CSRFTOKEN, anoncsrf, csrf_token, _csrf, _csrfSecret, __csrf_magic, CSRF] was found in the following HTML form: [Form 1: "SearchString" ].</p>
  
### Reference
* http://projects.webappsec.org/Cross-Site-Request-Forgery
* http://cwe.mitre.org/data/definitions/352.html

  
#### CWE Id : 352
  
#### WASC Id : 9
  
#### Source ID : 3

  
  
  
  
### Application Error Disclosure
##### Low (Medium)
  
  
  
  
#### Description
<p>This page contains an error/warning message that may disclose sensitive information like the location of the file that produced the unhandled exception. This information can be used to launch further attacks against the web application. The alert could be a false positive if the error message is found inside a documentation page.</p>
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0&sortOrder=Rating](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0&sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Genre](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Date](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0&sortOrder=name_desc](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0&sortOrder=name_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=0&sortOrder=Date](https://localhost:44325/Movies?pageNumber=0&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=rating_desc](https://localhost:44325/Novels?pageNumber=0&sortOrder=rating_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=Genre](https://localhost:44325/Novels?pageNumber=0&sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=name_desc](https://localhost:44325/Novels?pageNumber=0&sortOrder=name_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=0&sortOrder=Genre](https://localhost:44325/Movies?pageNumber=0&sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Rating](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=Publisher](https://localhost:44325/Novels?pageNumber=0&sortOrder=Publisher)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Director](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Director)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=0&sortOrder=rating_desc](https://localhost:44325/Movies?pageNumber=0&sortOrder=rating_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=0&sortOrder=date_desc](https://localhost:44325/Movies?pageNumber=0&sortOrder=date_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=Date](https://localhost:44325/Novels?pageNumber=0&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=0&sortOrder=genre_desc](https://localhost:44325/Movies?pageNumber=0&sortOrder=genre_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=genre_desc](https://localhost:44325/Novels?pageNumber=0&sortOrder=genre_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=publisher_desc](https://localhost:44325/Novels?pageNumber=0&sortOrder=publisher_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0&sortOrder=Date](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Evidence: `HTTP/1.1 500 Internal Server Error`
  
  
  
  
Instances: 33
  
### Solution
<p>Review the source code of this page. Implement custom error pages. Consider implementing a mechanism to provide a unique error reference/identifier to the client (browser) while logging the details on the server side and not exposing them to the user.</p>
  
### Reference
* 

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Cookie Without Secure Flag
##### Low (Medium)
  
  
  
  
#### Description
<p>A cookie has been set without the secure flag, which means that the cookie can be accessed via unencrypted connections.</p>
  
  
  
* URL: [https://localhost:44325/Account/Register](https://localhost:44325/Account/Register)
  
  
  * Method: `GET`
  
  
  * Parameter: `.AspNetCore.Antiforgery.gzZZdkjmJNA`
  
  
  * Evidence: `Set-Cookie: .AspNetCore.Antiforgery.gzZZdkjmJNA`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn](https://localhost:44325/Account/LogIn)
  
  
  * Method: `GET`
  
  
  * Parameter: `.AspNetCore.Antiforgery.gzZZdkjmJNA`
  
  
  * Evidence: `Set-Cookie: .AspNetCore.Antiforgery.gzZZdkjmJNA`
  
  
  
  
* URL: [https://localhost:44325/Trivia](https://localhost:44325/Trivia)
  
  
  * Method: `GET`
  
  
  * Parameter: `.AspNetCore.Antiforgery.gzZZdkjmJNA`
  
  
  * Evidence: `Set-Cookie: .AspNetCore.Antiforgery.gzZZdkjmJNA`
  
  
  
  
Instances: 3
  
### Solution
<p>Whenever a cookie contains sensitive information or is a session token, then it should always be passed using an encrypted channel. Ensure that the secure flag is set for cookies containing such sensitive information.</p>
  
### Reference
* https://owasp.org/www-project-web-security-testing-guide/v41/4-Web_Application_Security_Testing/06-Session_Management_Testing/02-Testing_for_Cookies_Attributes.html

  
#### CWE Id : 614
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
Instances: 1
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Parameter: `Pragma`
  
  
  * Evidence: `cache`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `s-maxage=900,public`
  
  
  
  
Instances: 2
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://aus5.mozilla.org/update/3/SystemAddons/86.0/20210222142601/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.804%20(x64)/default/default/update.xml](https://aus5.mozilla.org/update/3/SystemAddons/86.0/20210222142601/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.804%20(x64)/default/default/update.xml)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `public, max-age=90`
  
  
  
  
Instances: 1
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json](https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=600`
  
  
  
  
Instances: 1
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=3&sortOrder=Date](https://localhost:44325/Novels?pageNumber=3&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP](https://localhost:44325/Movies?currentFilter=ZAP)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=2&sortOrder=Rating](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=2&sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn?returnUrl=%2FNovels%2FDelete%2F2](https://localhost:44325/Account/LogIn?returnUrl=%2FNovels%2FDelete%2F2)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44325/Movies/Details/175](https://localhost:44325/Movies/Details/175)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44325/Movies?sortOrder=Director](https://localhost:44325/Movies?sortOrder=Director)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn?returnUrl=%2FNovels%2FDelete%2F3](https://localhost:44325/Account/LogIn?returnUrl=%2FNovels%2FDelete%2F3)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44325/Movies/Details/394](https://localhost:44325/Movies/Details/394)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=2&sortOrder=name_desc](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=2&sortOrder=name_desc)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=2&sortOrder=Director](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=2&sortOrder=Director)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44325/Account/Register](https://localhost:44325/Account/Register)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44325/Trivia/Scores](https://localhost:44325/Trivia/Scores)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=1&sortOrder=Rating](https://localhost:44325/Movies?pageNumber=1&sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FEdit%2F210](https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FEdit%2F210)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn?returnUrl=%2FMovies%2FDelete%2F207](https://localhost:44325/Account/LogIn?returnUrl=%2FMovies%2FDelete%2F207)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F105](https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F105)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn?returnUrl=%2FMovies%2FCreate](https://localhost:44325/Account/LogIn?returnUrl=%2FMovies%2FCreate)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F456](https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F456)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44325/Movies/Details/659](https://localhost:44325/Movies/Details/659)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=3&sortOrder=Rating](https://localhost:44325/Movies?pageNumber=3&sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
Instances: 248
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/plugins?_expected=1603126502200](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/plugins?_expected=1603126502200)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-default-override-allowlist?_expected=1595254618540](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-default-override-allowlist?_expected=1595254618540)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/intermediates/changeset?_expected=1615298308467&_since=%221613980717109%22](https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/intermediates/changeset?_expected=1615298308467&_since=%221613980717109%22)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/top-sites?_expected=1611838808382](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/top-sites?_expected=1611838808382)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1614991099385&_since=%221613759892664%22](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1614991099385&_since=%221613759892664%22)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/onecrl/changeset?_expected=1614217822898&_since=%221612908330359%22](https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/onecrl/changeset?_expected=1614217822898&_since=%221612908330359%22)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/password-recipes?_expected=1600889167888](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/password-recipes?_expected=1600889167888)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/cert-revocations/changeset?_expected=1615298303325](https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/cert-revocations/changeset?_expected=1615298303325)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/anti-tracking-url-decoration?_expected=1564511755134](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/anti-tracking-url-decoration?_expected=1564511755134)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/cfr-fxa/changeset?_expected=1614634069929](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/cfr-fxa/changeset?_expected=1614634069929)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=whats-new-panel&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=whats-new-panel&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-telemetry?_expected=1613587794383](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-telemetry?_expected=1613587794383)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/language-dictionaries?_expected=1569410800356](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/language-dictionaries?_expected=1569410800356)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=message-groups&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=message-groups&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=cfr&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=cfr&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/pioneer-study-addons-v1/changeset?_expected=1607042143590](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/pioneer-study-addons-v1/changeset?_expected=1607042143590)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=partitioning-exempt-urls&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=partitioning-exempt-urls&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/public-suffix-list/changeset?_expected=1575468539758](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/public-suffix-list/changeset?_expected=1575468539758)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/partitioning-exempt-urls/changeset?_expected=1592906663254](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/partitioning-exempt-urls/changeset?_expected=1592906663254)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
Instances: 33
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Server Leaks Information via "X-Powered-By" HTTP Response Header Field(s)
##### Low (Medium)
  
  
  
  
#### Description
<p>The web/application server is leaking information via one or more "X-Powered-By" HTTP response headers. Access to such information may facilitate attackers identifying other frameworks/components your web application is reliant upon and the vulnerabilities such components may be subject to.</p>
  
  
  
* URL: [https://localhost:44325/Account/Register](https://localhost:44325/Account/Register)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Home/Privacy](https://localhost:44325/Home/Privacy)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=3&sortOrder=Director](https://localhost:44325/Movies?pageNumber=3&sortOrder=Director)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=2&sortOrder=name_desc](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=2&sortOrder=name_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies/Edit/445](https://localhost:44325/Movies/Edit/445)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies/Details/125](https://localhost:44325/Movies/Details/125)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&sortOrder=date_desc](https://localhost:44325/Movies?currentFilter=ZAP&sortOrder=date_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies/Delete/680](https://localhost:44325/Movies/Delete/680)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies/Details/210](https://localhost:44325/Movies/Details/210)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Novels?sortOrder=Date](https://localhost:44325/Novels?sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies/Edit/1](https://localhost:44325/Movies/Edit/1)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies/Delete/463](https://localhost:44325/Movies/Delete/463)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies/Details/124](https://localhost:44325/Movies/Details/124)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Novels](https://localhost:44325/Novels)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn?returnUrl=%2FHome%2FForum](https://localhost:44325/Account/LogIn?returnUrl=%2FHome%2FForum)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FEdit%2F459](https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FEdit%2F459)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies/Delete/681](https://localhost:44325/Movies/Delete/681)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=name_desc](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=name_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=2&sortOrder=date_desc](https://localhost:44325/Movies?pageNumber=2&sortOrder=date_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44325/Movies/Edit/2](https://localhost:44325/Movies/Edit/2)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
Instances: 411
  
### Solution
<p>Ensure that your web server, application server, load balancer, etc. is configured to suppress "X-Powered-By" headers.</p>
  
### Reference
* http://blogs.msdn.com/b/varunm/archive/2013/04/23/remove-unwanted-http-response-headers.aspx
* http://www.troyhunt.com/2012/02/shhh-dont-let-your-response-headers.html

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://ftp.mozilla.org/pub/system-addons/reset-search-defaults/reset-search-defaults@mozilla.com-1.0.5-signed.xpi](https://ftp.mozilla.org/pub/system-addons/reset-search-defaults/reset-search-defaults@mozilla.com-1.0.5-signed.xpi)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json](https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://content-signature-2.cdn.mozilla.net/chains/pinning-preload.content-signature.mozilla.org-2021-04-12-15-03-52.chain](https://content-signature-2.cdn.mozilla.net/chains/pinning-preload.content-signature.mozilla.org-2021-04-12-15-03-52.chain)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://content-signature-2.cdn.mozilla.net/chains/remote-settings.content-signature.mozilla.org-2021-04-12-15-03-53.chain](https://content-signature-2.cdn.mozilla.net/chains/remote-settings.content-signature.mozilla.org-2021-04-12-15-03-53.chain)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://content-signature-2.cdn.mozilla.net/chains/onecrl.content-signature.mozilla.org-2021-04-12-15-03-50.chain](https://content-signature-2.cdn.mozilla.net/chains/onecrl.content-signature.mozilla.org-2021-04-12-15-03-50.chain)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 3
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-facebook-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-facebook-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/block-flash-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/block-flash-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/content-track-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/content-track-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/analytics-track-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/analytics-track-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flashallow-digest256/1490633678](https://tracking-protection.cdn.mozilla.net/except-flashallow-digest256/1490633678)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flashsubdoc-digest256/1517935265](https://tracking-protection.cdn.mozilla.net/except-flashsubdoc-digest256/1517935265)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/ads-track-digest256/1611614019](https://tracking-protection.cdn.mozilla.net/ads-track-digest256/1611614019)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/google-trackwhite-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/google-trackwhite-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-twitter-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-twitter-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/block-flashsubdoc-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/block-flashsubdoc-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-linkedin-digest256/1564526481](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-linkedin-digest256/1564526481)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/mozstd-trackwhite-digest256/1611614019](https://tracking-protection.cdn.mozilla.net/mozstd-trackwhite-digest256/1611614019)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/base-cryptomining-track-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/base-cryptomining-track-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-track-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/social-track-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flash-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/except-flash-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/base-fingerprinting-track-digest256/1608186823](https://tracking-protection.cdn.mozilla.net/base-fingerprinting-track-digest256/1608186823)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/allow-flashallow-digest256/1490633678](https://tracking-protection.cdn.mozilla.net/allow-flashallow-digest256/1490633678)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 17
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://localhost:44325/Movies/Details/1](https://localhost:44325/Movies/Details/1)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/Register](https://localhost:44325/Account/Register)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F547](https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F547)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn?returnUrl=%2FNovels%2FDelete%2F3](https://localhost:44325/Account/LogIn?returnUrl=%2FNovels%2FDelete%2F3)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies/Details/58](https://localhost:44325/Movies/Details/58)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=1&sortOrder=Director](https://localhost:44325/Movies?pageNumber=1&sortOrder=Director)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=1&sortOrder=Genre](https://localhost:44325/Movies?pageNumber=1&sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn?returnUrl=%2FNovels%2FDelete%2F2](https://localhost:44325/Account/LogIn?returnUrl=%2FNovels%2FDelete%2F2)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=2&sortOrder=director_desc](https://localhost:44325/Movies?pageNumber=2&sortOrder=director_desc)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=1&sortOrder=Date](https://localhost:44325/Movies?pageNumber=1&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F678](https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F678)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=2&sortOrder=Rating](https://localhost:44325/Movies?pageNumber=2&sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&sortOrder=publisher_desc](https://localhost:44325/Novels?currentFilter=ZAP&sortOrder=publisher_desc)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F459](https://localhost:44325/Account/Login?ReturnUrl=%2FMovies%2FDelete%2F459)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies/Details/515](https://localhost:44325/Movies/Details/515)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/lib/bootstrap/dist/css/bootstrap.min.css](https://localhost:44325/lib/bootstrap/dist/css/bootstrap.min.css)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn?returnUrl=%2FNovels%2FEdit%2F1](https://localhost:44325/Account/LogIn?returnUrl=%2FNovels%2FEdit%2F1)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=4](https://localhost:44325/Novels?pageNumber=4)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/images/StephenKingAdaptations_Getty_NewLineCinema_GreenEpsteinProductions_Ringer.0.jpg](https://localhost:44325/images/StephenKingAdaptations_Getty_NewLineCinema_GreenEpsteinProductions_Ringer.0.jpg)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44325/Movies/Details/319](https://localhost:44325/Movies/Details/319)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 259
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Charset Mismatch 
##### Informational (Low)
  
  
  
  
#### Description
<p>This check identifies responses where the HTTP Content-Type header declares a charset different from the charset defined by the body of the HTML or XML. When there's a charset mismatch between the HTTP header and content body Web browsers can be forced into an undesirable content-sniffing mode to determine the content's correct character set.</p><p></p><p>An attacker could manipulate content on the page to be interpreted in an encoding of their choice. For example, if an attacker can control content at the beginning of the page, they could inject script using UTF-7 encoded text and manipulate some browsers into interpreting that text.</p>
  
  
  
* URL: [https://aus5.mozilla.org/update/3/SystemAddons/86.0/20210222142601/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.804%20(x64)/default/default/update.xml](https://aus5.mozilla.org/update/3/SystemAddons/86.0/20210222142601/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.804%20(x64)/default/default/update.xml)
  
  
  * Method: `GET`
  
  
  
  
Instances: 1
  
### Solution
<p>Force UTF-8 for all text content in both the HTTP header and meta tags in HTML or encoding declarations in XML.</p>
  
### Other information
<p>There was a charset mismatch between the HTTP Header and the XML encoding declaration: [utf-8] and [null] do not match.</p>
  
### Reference
* http://code.google.com/p/browsersec/wiki/Part2#Character_set_handling_and_detection

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Information Disclosure - Suspicious Comments
##### Informational (Low)
  
  
  
  
#### Description
<p>The response appears to contain suspicious comments which may help an attacker. Note: Matches made within script blocks or files are against the entire content not only comments.</p>
  
  
  
* URL: [https://localhost:44325/lib/bootstrap/dist/js/bootstrap.bundle.min.js](https://localhost:44325/lib/bootstrap/dist/js/bootstrap.bundle.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `from`
  
  
  
  
* URL: [https://localhost:44325/lib/jquery/dist/jquery.min.js](https://localhost:44325/lib/jquery/dist/jquery.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `username`
  
  
  
  
Instances: 2
  
### Solution
<p>Remove all comments that return information that may help an attacker and fix any underlying problems they refer to.</p>
  
### Other information
<p>The following pattern was used: \bFROM\b and was detected in the element starting with: "!function(t,e){"object"==typeof exports&&"undefined"!=typeof module?e(exports,require("jquery")):"function"==typeof define&&defi", see evidence field for the suspicious comment/snippet.</p>
  
### Reference
* 

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Loosely Scoped Cookie
##### Informational (Low)
  
  
  
  
#### Description
<p>Cookies can be scoped by domain or path. This check is only concerned with domain scope.The domain scope applied to a cookie determines which domains can access it. For example, a cookie can be scoped strictly to a subdomain e.g. www.nottrusted.com, or loosely scoped to a parent domain e.g. nottrusted.com. In the latter case, any subdomain of nottrusted.com can access the cookie. Loosely scoped cookies are common in mega-applications like google.com and live.com. Cookies set from a subdomain like app.foo.bar are transmitted only to that domain by the browser. However, cookies scoped to a parent-level domain may be transmitted to the parent, or any subdomain of the parent.</p>
  
  
  
* URL: [https://localhost:44325/Trivia](https://localhost:44325/Trivia)
  
  
  * Method: `GET`
  
  
  
  
* URL: [https://localhost:44325/Account/Register](https://localhost:44325/Account/Register)
  
  
  * Method: `GET`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn](https://localhost:44325/Account/LogIn)
  
  
  * Method: `GET`
  
  
  
  
* URL: [https://localhost:44325/Account/LogIn](https://localhost:44325/Account/LogIn)
  
  
  * Method: `POST`
  
  
  
  
Instances: 4
  
### Solution
<p>Always scope cookies to a FQDN (Fully Qualified Domain Name).</p>
  
### Other information
<p>The origin domain used for comparison was: </p><p>localhost</p><p>.AspNetCore.Antiforgery.gzZZdkjmJNA=CfDJ8JigQVXMJtVNqUeJRVxaAJsw2w3V7n4BDp4ofz33rxgO77UWueg5Xk2xnDU1PDTRAgHkpncPTyUokaa90N-jzrpahxXkhUVSOvSCI5FNrgjOJfimbpeIqZPGAEDVlDP6gw-LEyGXjaQzO-pP_1IWPK4</p><p></p>
  
### Reference
* https://tools.ietf.org/html/rfc6265#section-4.1
* https://owasp.org/www-project-web-security-testing-guide/v41/4-Web_Application_Security_Testing/06-Session_Management_Testing/02-Testing_for_Cookies_Attributes.html
* http://code.google.com/p/browsersec/wiki/Part2#Same-origin_policy_for_cookies

  
#### CWE Id : 565
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Timestamp Disclosure - Unix
##### Informational (Low)
  
  
  
  
#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `23064681`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `23080432`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `22843503`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `21882261`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `22843426`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `15210963`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `15417547`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `15432059`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `22843399`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `15211446`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `22842419`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `15211100`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `15253015`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `23067108`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `487384333`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `294201780`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `15246625`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `15435959`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `22843562`
  
  
  
  
* URL: [https://spocs.getpocket.com/spocs](https://spocs.getpocket.com/spocs)
  
  
  * Method: `POST`
  
  
  * Evidence: `22892052`
  
  
  
  
Instances: 59
  
### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>
  
### Other information
<p>23064681, which evaluates to: 1970-09-24 15:51:21</p>
  
### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Timestamp Disclosure - Unix
##### Informational (Low)
  
  
  
  
#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1614200443`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1614661266`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1614960420`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1614924000`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `974534021`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1556686800`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `997646290`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1614905700`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1615201140`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1614715756`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1615096800`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1614060000`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1614716511`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `22350347`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1069569786`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1614146400`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `22343223`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1614751200`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1614578400`
  
  
  
  
* URL: [https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30](https://getpocket.cdn.mozilla.net/v3/firefox/global-recs?version=3&consumer_key=40249-e88c401e1b1f2242d9e441c4&locale_lang=en-US&region=US&count=30)
  
  
  * Method: `GET`
  
  
  * Evidence: `1615111202`
  
  
  
  
Instances: 33
  
### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>
  
### Other information
<p>1614200443, which evaluates to: 2021-02-24 13:00:43</p>
  
### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Timestamp Disclosure - Unix
##### Informational (Low)
  
  
  
  
#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/block-flashsubdoc-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/block-flashsubdoc-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/allow-flashallow-digest256/1490633678](https://tracking-protection.cdn.mozilla.net/allow-flashallow-digest256/1490633678)
  
  
  * Method: `GET`
  
  
  * Evidence: `1490633678`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flashallow-digest256/1490633678](https://tracking-protection.cdn.mozilla.net/except-flashallow-digest256/1490633678)
  
  
  * Method: `GET`
  
  
  * Evidence: `1490633678`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/base-cryptomining-track-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/base-cryptomining-track-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-linkedin-digest256/1564526481](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-linkedin-digest256/1564526481)
  
  
  * Method: `GET`
  
  
  * Evidence: `1564526481`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flash-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/except-flash-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-facebook-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-facebook-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flashsubdoc-digest256/1517935265](https://tracking-protection.cdn.mozilla.net/except-flashsubdoc-digest256/1517935265)
  
  
  * Method: `GET`
  
  
  * Evidence: `1517935265`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/ads-track-digest256/1611614019](https://tracking-protection.cdn.mozilla.net/ads-track-digest256/1611614019)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611614019`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/analytics-track-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/analytics-track-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/block-flash-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/block-flash-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/mozstd-trackwhite-digest256/1611614019](https://tracking-protection.cdn.mozilla.net/mozstd-trackwhite-digest256/1611614019)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611614019`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-twitter-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-twitter-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/base-fingerprinting-track-digest256/1608186823](https://tracking-protection.cdn.mozilla.net/base-fingerprinting-track-digest256/1608186823)
  
  
  * Method: `GET`
  
  
  * Evidence: `1608186823`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-track-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/social-track-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/content-track-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/content-track-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/google-trackwhite-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/google-trackwhite-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
Instances: 17
  
### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>
  
### Other information
<p>1604686195, which evaluates to: 2020-11-06 10:09:55</p>
  
### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Timestamp Disclosure - Unix
##### Informational (Low)
  
  
  
  
#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=0&sortOrder=rating_desc](https://localhost:44325/Movies?pageNumber=0&sortOrder=rating_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=date_desc](https://localhost:44325/Novels?pageNumber=0&sortOrder=date_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=Publisher](https://localhost:44325/Novels?pageNumber=0&sortOrder=Publisher)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=genre_desc](https://localhost:44325/Novels?pageNumber=0&sortOrder=genre_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=0&sortOrder=Rating](https://localhost:44325/Movies?pageNumber=0&sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=publisher_desc](https://localhost:44325/Novels?pageNumber=0&sortOrder=publisher_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/images/PSTRAIN_KING_WEB_1200.jpg](https://localhost:44325/images/PSTRAIN_KING_WEB_1200.jpg)
  
  
  * Method: `GET`
  
  
  * Evidence: `66323660`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Rating](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=name_desc](https://localhost:44325/Novels?pageNumber=0&sortOrder=name_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=0&sortOrder=Genre](https://localhost:44325/Movies?pageNumber=0&sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Genre](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Genre)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=0&sortOrder=genre_desc](https://localhost:44325/Movies?pageNumber=0&sortOrder=genre_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0&sortOrder=Date](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Movies?pageNumber=0&sortOrder=date_desc](https://localhost:44325/Movies?pageNumber=0&sortOrder=date_desc)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Novels?pageNumber=0&sortOrder=Date](https://localhost:44325/Novels?pageNumber=0&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Director](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Director)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Date](https://localhost:44325/Movies?currentFilter=ZAP&pageNumber=0&sortOrder=Date)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
* URL: [https://localhost:44325/images/PSTRAIN_KING_WEB_1200.jpg](https://localhost:44325/images/PSTRAIN_KING_WEB_1200.jpg)
  
  
  * Method: `GET`
  
  
  * Evidence: `2147483647`
  
  
  
  
* URL: [https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0&sortOrder=Rating](https://localhost:44325/Novels?currentFilter=ZAP&pageNumber=0&sortOrder=Rating)
  
  
  * Method: `GET`
  
  
  * Evidence: `20100101`
  
  
  
  
Instances: 35
  
### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>
  
### Other information
<p>20100101, which evaluates to: 1970-08-21 08:21:41</p>
  
### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Timestamp Disclosure - Unix
##### Informational (Low)
  
  
  
  
#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/cert-revocations/changeset?_expected=1615298303325](https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/cert-revocations/changeset?_expected=1615298303325)
  
  
  * Method: `GET`
  
  
  * Evidence: `20210303`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `10604307`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `15025407`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `49038354`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `77159696`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `86591957`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `26183992`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `22437749`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1614991099385&_since=%221613759892664%22](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1614991099385&_since=%221613759892664%22)
  
  
  * Method: `GET`
  
  
  * Evidence: `77063849`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `11657763`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `36395491`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `40767652`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/cfr/changeset?_expected=1615301936682](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/cfr/changeset?_expected=1615301936682)
  
  
  * Method: `GET`
  
  
  * Evidence: `86400000`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/cert-revocations/changeset?_expected=1615298303325](https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/cert-revocations/changeset?_expected=1615298303325)
  
  
  * Method: `GET`
  
  
  * Evidence: `20210309`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `14610585`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `172869660`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `20012235`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `13369666`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `23927853`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1614777807716)
  
  
  * Method: `GET`
  
  
  * Evidence: `29020808`
  
  
  
  
Instances: 126
  
### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>
  
### Other information
<p>20210303, which evaluates to: 1970-08-22 14:58:23</p>
  
### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Timestamp Disclosure - Unix
##### Informational (Low)
  
  
  
  
#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Evidence: `1564526481`
  
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Evidence: `1490633678`
  
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Evidence: `1608186823`
  
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Evidence: `1611614019`
  
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Evidence: `1517935265`
  
  
  
  
Instances: 6
  
### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>
  
### Other information
<p>1564526481, which evaluates to: 2019-07-30 15:41:21</p>
  
### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3
